using OpenTK;
using SimpleGameEngine.Graphics.Assets;
using Smash.Game.Fighter;
using Smash.Game.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.GraphicWrangler
{
    public class Animator
    {
        public string CurrentAnimationName { get; private set; } = "";
        public Dictionary<string, RenderAnimation> Animations { get; set; } = new Dictionary<string, RenderAnimation>();
        RenderAnimation currentanimation
        {
            get
            {
                if (Animations.ContainsKey(CurrentAnimationName))
                {
                    return Animations[CurrentAnimationName];
                }
                else
                {
                    return null;
                }
            }
        }
        public fighter fighterref { get; set; }
        public float AnimationSpeed { get; set; } = 1;
        public float FinalSpeed => fighterref.FinalSpeed * AnimationSpeed;
        public bool FinishedAnimation { get; private set; }
        public bool LerpedAnimation { get; private set; }
        public float CurrentKey { get; set; } 
        public float KeyDecimal { get; private set; }
        public int CurrentKeyIndex => (int)CurrentKey;
        public float MovementX { get; set; }
        public float MovementY { get; set; }
        public bool AnimationChange { get; set; }
        public Animator()
        {

        }

        public void Update()
        {
            if (currentanimation != null)
            {
                LerpAnimation();
                
                UpdateSkeleton();

                UpdateTime();
            }

            AnimationOverides = new List<string>();
        }

        List<string> AnimationOverides { get; set; } = new List<string>();

        public void OverrideNode(string name)
        {
            AnimationOverides.Add(name);
        }

        public void UpdateSkeleton()
        {
            foreach (AnimationNode node in currentanimation.Nodes)
            {
                if (node.Type == TrackType.Transform)
                {
                    if (CurrentKeyIndex < node.FrameCount)
                    {
                        TransformNode Bone = fighterref.Model.Skeleton.GetNode(node.Name);

                        if (Bone != null && !AnimationOverides.Contains(node.Name))
                        {
                            Tuple<AnimationTransform, AnimationTransform> Keys = node.GetCurrentNextKey<AnimationTransform>(CurrentKeyIndex);

                            AnimationTransform current = Bone.GetAnimationNode();
                            AnimationTransform final = LerpTransforms(Keys.Item1, Keys.Item2, KeyDecimal);

                            AnimationTransform bonetransform = LerpTransforms(current, final, TransitionLerp);

                            if (Bone.Name != "Trans")
                            {
                                Bone.SetNodeTransform(bonetransform);
                            }
                            else
                            {
                                Bone.WantedPosition = bonetransform.Position;

                                if (CurrentKeyIndex + 1 < currentanimation.FrameCount)
                                {
                                    MovementX = (Keys.Item2.Position.Z - Keys.Item1.Position.Z) * AnimationSpeed;
                                    MovementY = (Keys.Item2.Position.Y - Keys.Item1.Position.Y) * AnimationSpeed;
                                }
                            }
                        }
                    }
                }
                
                if (node.Type == TrackType.Visibility)
                {
                    if (CurrentKeyIndex < node.FrameCount)
                    {
                        if (fighterref.Model.RenderKeys.ContainsKey(node.Name))
                        {
                            List<SkinnedMeshRenderer> renderers = fighterref.Model.RenderKeys[node.Name];

                            foreach (SkinnedMeshRenderer renderer in renderers)
                            {
                                renderer.Active = node.GetKey<bool>(CurrentKeyIndex);
                            }
                        }
                    }
                }
            }
        }

        public void UpdateTime()
        {
            CurrentKey += FinalSpeed;

            KeyDecimal = CurrentKey - (int)CurrentKey;

            if (FinishedAnimation)
            {
                CurrentKey -= currentanimation.FrameCount +1;

                FinishedAnimation = false;

                AnimationChange = true;
            }

            if (!(CurrentKeyIndex < currentanimation.FrameCount))
            {
                FinishedAnimation = true;
            }

            LerpedAnimation = false;

            if (CurrentKey < 0)
                CurrentKey = 0;

            AnimationSpeed = 1;
        }

        public static AnimationTransform LerpTransforms(AnimationTransform x,AnimationTransform y, float lerp)
        {
            return new AnimationTransform()
            {
                Position = Vector3.Lerp(x.Position, y.Position, lerp),
                Rotation = Quaternion.Slerp(x.Rotation, y.Rotation, lerp),
                Scale = Vector3.Lerp(x.Scale,y.Scale,lerp)
            };
        }

        public float LerpPosition { get; private set; }
        public int LerpEnd { get; private set; }
        public float TransitionLerp { get; private set; } = 1;
        public void LerpAnimation()
        {
            if (LerpEnd != 0)
            {
                LerpPosition += FinalSpeed;

                TransitionLerp = LerpPosition / LerpEnd;

                if (LerpPosition >= LerpEnd)
                {
                    LerpPosition = 0;
                    LerpEnd = 0;
                }
            }
            else
            {
                TransitionLerp = 1;
            }
        }

        public void CrossFade(string Name,int CrossTime = 0, bool force = false,bool reset = true)
        {
            if (Name != CurrentAnimationName || force)
            {
                CurrentAnimationName = Name;

                LerpEnd = CrossTime;

                if (reset)
                {
                    CurrentKey = 0;
                    LerpPosition = 0;
                }

                LerpedAnimation = true;
                AnimationChange = true;
            }
        }

        public static string GetAnimationName(string In)
        {
            string Out = "";

            for (int i = 3; i < In.Length; i++)
            {
                Out += In[i];
            }

            return Out.Replace('+','_');
        }

        public void PauseInAnimation(int index)
        {
            if (CurrentKeyIndex >= index)
                CurrentKey = index;
        }
    }
}
