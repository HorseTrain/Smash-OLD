using OpenTK;
using SimpleGameEngine.Graphics;
using Smash.Game.Fighter.Particals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smash.Game.Fighter
{
    public partial class fighter
    {
        public virtual void ScriptMain()
        {
            switch (anim.CurrentAnimationName)
            {
                case "defaulteyelid": anm_defaulteyelid(); break;
                case "itemhandgrip": anm_itemhandgrip(); break;
                case "itemhandhave": anm_itemhandhave(); break;
                case "itemhandpickup": anm_itemhandpickup(); break;
                case "itemhandsmash": anm_itemhandsmash(); break;
                case "wait1": anm_wait1(); break;
                case "wait3": anm_wait3(); break;
                case "wait4": anm_wait4(); break;
                case "wait5": anm_wait5(); break;
                case "waititem": anm_waititem(); break;
                case "turn": anm_turn(); break;
                case "walkbrakel": anm_walkbrakel(); break;
                case "walkbraker": anm_walkbraker(); break;
                case "walkfast": anm_walkfast(); break;
                case "walkmiddle": anm_walkmiddle(); break;
                case "walkslow": anm_walkslow(); break;
                case "dash": anm_dash(); break;
                case "run": anm_run(); break;
                case "runbrakel": anm_runbrakel(); break;
                case "runbraker": anm_runbraker(); break;
                case "turndash": anm_turndash(); break;
                case "turnrun": anm_turnrun(); break;
                case "turnrunbrake": anm_turnrunbrake(); break;
                case "jumpaerialb": anm_jumpaerialb(); break;
                case "jumpaerialf": anm_jumpaerialf(); break;
                case "jumpb": anm_jumpb(); break;
                case "jumpf": anm_jumpf(); break;
                case "jumpsquat": anm_jumpsquat(); break;
                case "damagefall": anm_damagefall(); break;
                case "fall": anm_fall(); break;
                case "fallaerial": anm_fallaerial(); break;
                case "fallaerialb": anm_fallaerialb(); break;
                case "fallaerialf": anm_fallaerialf(); break;
                case "fallb": anm_fallb(); break;
                case "fallf": anm_fallf(); break;
                case "fallspecial": anm_fallspecial(); break;
                case "fallspecialb": anm_fallspecialb(); break;
                case "fallspecialf": anm_fallspecialf(); break;
                case "landingfallspecial": anm_landingfallspecial(); break;
                case "runfalll": anm_runfalll(); break;
                case "runfallr": anm_runfallr(); break;
                case "walkfalll": anm_walkfalll(); break;
                case "walkfallr": anm_walkfallr(); break;
                case "landingheavy": anm_landingheavy(); break;
                case "landinglight": anm_landinglight(); break;
                case "squat": anm_squat(); break;
                case "squatrv": anm_squatrv(); break;
                case "squatwait": anm_squatwait(); break;
                case "squatwaititem": anm_squatwaititem(); break;
                case "stepairpose": anm_stepairpose(); break;
                case "stepback": anm_stepback(); break;
                case "stepfall": anm_stepfall(); break;
                case "stepjump": anm_stepjump(); break;
                case "steppose": anm_steppose(); break;
                case "guard": anm_guard(); break;
                case "guardoff": anm_guardoff(); break;
                case "guardon": anm_guardon(); break;
                case "justshieldoff": anm_justshieldoff(); break;
                case "guarddamage": anm_guarddamage(); break;
                case "escapeair": anm_escapeair(); break;
                case "escapeb": anm_escapeb(); break;
                case "escapef": anm_escapef(); break;
                case "escapen": anm_escapen(); break;
                case "rebound": anm_rebound(); break;
                case "attack100": anm_attack100(); break;
                case "attack100start": anm_attack100start(); break;
                case "attack11": anm_attack11(); break;
                case "attack12": anm_attack12(); break;
                case "attack13": anm_attack13(); break;
                case "attackdash": anm_attackdash(); break;
                case "attackend": anm_attackend(); break;
                case "attacks3": anm_attacks3(); break;
                case "attacks32": anm_attacks32(); break;
                case "attacks33": anm_attacks33(); break;
                case "attackhi3": anm_attackhi3(); break;
                case "attacklw3": anm_attacklw3(); break;
                case "attacks4charge": anm_attacks4charge(); break;
                case "attacks4hi": anm_attacks4hi(); break;
                case "attacks4lw": anm_attacks4lw(); break;
                case "attacks4s": anm_attacks4s(); break;
                case "attackhi4": anm_attackhi4(); break;
                case "attackhi4charge": anm_attackhi4charge(); break;
                case "attacklw4": anm_attacklw4(); break;
                case "attacklw4charge": anm_attacklw4charge(); break;
                case "attackairb": anm_attackairb(); break;
                case "attackairf": anm_attackairf(); break;
                case "attackairf2": anm_attackairf2(); break;
                case "attackairf3": anm_attackairf3(); break;
                case "attackairhi": anm_attackairhi(); break;
                case "attackairhihold": anm_attackairhihold(); break;
                case "attackairlw": anm_attackairlw(); break;
                case "attackairn": anm_attackairn(); break;
                case "attackairnhold": anm_attackairnhold(); break;
                case "landingairb": anm_landingairb(); break;
                case "landingairf": anm_landingairf(); break;
                case "landingairf2": anm_landingairf2(); break;
                case "landingairf3": anm_landingairf3(); break;
                case "landingairhi": anm_landingairhi(); break;
                case "landingairlw": anm_landingairlw(); break;
                case "landingairn": anm_landingairn(); break;
                case "specialairnchargef": anm_specialairnchargef(); break;
                case "specialairnchargeh": anm_specialairnchargeh(); break;
                case "specialairnendf": anm_specialairnendf(); break;
                case "specialairnendh": anm_specialairnendh(); break;
                case "specialairnloopf": anm_specialairnloopf(); break;
                case "specialairnlooph": anm_specialairnlooph(); break;
                case "specialairnstartf": anm_specialairnstartf(); break;
                case "specialairnstarth": anm_specialairnstarth(); break;
                case "specialnchargef": anm_specialnchargef(); break;
                case "specialnchargeh": anm_specialnchargeh(); break;
                case "specialnendf": anm_specialnendf(); break;
                case "specialnendh": anm_specialnendh(); break;
                case "specialnloopf": anm_specialnloopf(); break;
                case "specialnlooph": anm_specialnlooph(); break;
                case "specialnstartf": anm_specialnstartf(); break;
                case "specialnstarth": anm_specialnstarth(); break;
                case "specialairsd": anm_specialairsd(); break;
                case "specialairsdhit": anm_specialairsdhit(); break;
                case "specialairsdlanding": anm_specialairsdlanding(); break;
                case "specialairsu": anm_specialairsu(); break;
                case "specials": anm_specials(); break;
                case "specialsholdend": anm_specialsholdend(); break;
                case "specialairhi": anm_specialairhi(); break;
                case "specialhi": anm_specialhi(); break;
                case "specialairlw": anm_specialairlw(); break;
                case "speciallw": anm_speciallw(); break;
                case "final": anm_final(); break;
                case "finalair": anm_finalair(); break;
                case "finalairendl": anm_finalairendl(); break;
                case "finalairendr": anm_finalairendr(); break;
                case "finalendl": anm_finalendl(); break;
                case "finalendr": anm_finalendr(); break;
                case "finalvisualscene01": anm_finalvisualscene01(); break;
                case "catch": anm_catch(); break;
                case "catchattack": anm_catchattack(); break;
                case "catchcut": anm_catchcut(); break;
                case "catchdash": anm_catchdash(); break;
                case "catchpull": anm_catchpull(); break;
                case "catchturn": anm_catchturn(); break;
                case "catchwait": anm_catchwait(); break;
                case "throwb": anm_throwb(); break;
                case "throwf": anm_throwf(); break;
                case "throwhi": anm_throwhi(); break;
                case "throwlw": anm_throwlw(); break;
                case "thrownb": anm_thrownb(); break;
                case "thrownbigb": anm_thrownbigb(); break;
                case "thrownbigf": anm_thrownbigf(); break;
                case "thrownbighi": anm_thrownbighi(); break;
                case "thrownbiglw": anm_thrownbiglw(); break;
                case "throwndxb": anm_throwndxb(); break;
                case "throwndxf": anm_throwndxf(); break;
                case "throwndxhi": anm_throwndxhi(); break;
                case "throwndxlw": anm_throwndxlw(); break;
                case "thrownf": anm_thrownf(); break;
                case "throwngirlb": anm_throwngirlb(); break;
                case "throwngirlf": anm_throwngirlf(); break;
                case "throwngirlhi": anm_throwngirlhi(); break;
                case "throwngirllw": anm_throwngirllw(); break;
                case "thrownhi": anm_thrownhi(); break;
                case "thrownlw": anm_thrownlw(); break;
                case "capturedamagehi": anm_capturedamagehi(); break;
                case "capturepulledhi": anm_capturepulledhi(); break;
                case "capturewaithi": anm_capturewaithi(); break;
                case "capturecut": anm_capturecut(); break;
                case "capturedamagelw": anm_capturedamagelw(); break;
                case "capturejump": anm_capturejump(); break;
                case "capturepulledlw": anm_capturepulledlw(); break;
                case "capturewaitlw": anm_capturewaitlw(); break;
                case "damagehi1": anm_damagehi1(); break;
                case "damagehi2": anm_damagehi2(); break;
                case "damagehi3": anm_damagehi3(); break;
                case "damagelw1": anm_damagelw1(); break;
                case "damagelw2": anm_damagelw2(); break;
                case "damagelw3": anm_damagelw3(); break;
                case "damagen1": anm_damagen1(); break;
                case "damagen2": anm_damagen2(); break;
                case "damagen3": anm_damagen3(); break;
                case "damageair1": anm_damageair1(); break;
                case "damageair2": anm_damageair2(); break;
                case "damageair3": anm_damageair3(); break;
                case "damageflyhi": anm_damageflyhi(); break;
                case "damageflylw": anm_damageflylw(); break;
                case "damageflymeteor": anm_damageflymeteor(); break;
                case "damageflyn": anm_damageflyn(); break;
                case "damageflyroll": anm_damageflyroll(); break;
                case "damageflyrollend": anm_damageflyrollend(); break;
                case "damageflytop": anm_damageflytop(); break;
                case "damageelec": anm_damageelec(); break;
                case "downattacku": anm_downattacku(); break;
                case "downbacku": anm_downbacku(); break;
                case "downboundu": anm_downboundu(); break;
                case "downdamageu": anm_downdamageu(); break;
                case "downdamageu3": anm_downdamageu3(); break;
                case "downeatu": anm_downeatu(); break;
                case "downforwardu": anm_downforwardu(); break;
                case "downstandu": anm_downstandu(); break;
                case "downwaitu": anm_downwaitu(); break;
                case "downattackd": anm_downattackd(); break;
                case "downbackd": anm_downbackd(); break;
                case "downboundd": anm_downboundd(); break;
                case "downdamaged": anm_downdamaged(); break;
                case "downdamaged3": anm_downdamaged3(); break;
                case "downeatd": anm_downeatd(); break;
                case "downforwardd": anm_downforwardd(); break;
                case "downspotd": anm_downspotd(); break;
                case "downstandd": anm_downstandd(); break;
                case "downwaitd": anm_downwaitd(); break;
                case "passive": anm_passive(); break;
                case "passiveceil": anm_passiveceil(); break;
                case "passivestandb": anm_passivestandb(); break;
                case "passivestandf": anm_passivestandf(); break;
                case "passivewall": anm_passivewall(); break;
                case "passivewalljump": anm_passivewalljump(); break;
                case "furafura": anm_furafura(); break;
                case "furafuraend": anm_furafuraend(); break;
                case "furafurastartd": anm_furafurastartd(); break;
                case "furafurastartu": anm_furafurastartu(); break;
                case "sleepend": anm_sleepend(); break;
                case "sleeploop": anm_sleeploop(); break;
                case "sleepstart": anm_sleepstart(); break;
                case "swallowed": anm_swallowed(); break;
                case "ceildamage": anm_ceildamage(); break;
                case "missfoot": anm_missfoot(); break;
                case "ottotto": anm_ottotto(); break;
                case "ottottowait": anm_ottottowait(); break;
                case "pass": anm_pass(); break;
                case "stopceil": anm_stopceil(); break;
                case "stopwall": anm_stopwall(); break;
                case "walldamage": anm_walldamage(); break;
                case "cliffcatch": anm_cliffcatch(); break;
                case "cliffwait": anm_cliffwait(); break;
                case "cliffattack": anm_cliffattack(); break;
                case "cliffclimb": anm_cliffclimb(); break;
                case "cliffescape": anm_cliffescape(); break;
                case "cliffjump1": anm_cliffjump1(); break;
                case "cliffjump2": anm_cliffjump2(); break;
                case "slip": anm_slip(); break;
                case "slipattack": anm_slipattack(); break;
                case "slipdown": anm_slipdown(); break;
                case "slipescapeb": anm_slipescapeb(); break;
                case "slipescapef": anm_slipescapef(); break;
                case "slipstand": anm_slipstand(); break;
                case "slipwait": anm_slipwait(); break;
                case "lighteat": anm_lighteat(); break;
                case "lightget": anm_lightget(); break;
                case "lightwalkeat": anm_lightwalkeat(); break;
                case "lightwalkget": anm_lightwalkget(); break;
                case "lightthrowb": anm_lightthrowb(); break;
                case "lightthrowdash": anm_lightthrowdash(); break;
                case "lightthrowdrop": anm_lightthrowdrop(); break;
                case "lightthrowf": anm_lightthrowf(); break;
                case "lightthrowhi": anm_lightthrowhi(); break;
                case "lightthrowlw": anm_lightthrowlw(); break;
                case "lightthrowairb": anm_lightthrowairb(); break;
                case "lightthrowairf": anm_lightthrowairf(); break;
                case "lightthrowairhi": anm_lightthrowairhi(); break;
                case "lightthrowairlw": anm_lightthrowairlw(); break;
                case "heavyget": anm_heavyget(); break;
                case "heavythrowb": anm_heavythrowb(); break;
                case "heavythrowf": anm_heavythrowf(); break;
                case "heavythrowhi": anm_heavythrowhi(); break;
                case "heavythrowlw": anm_heavythrowlw(); break;
                case "heavywalk": anm_heavywalk(); break;
                case "swing1": anm_swing1(); break;
                case "swing3": anm_swing3(); break;
                case "swing4": anm_swing4(); break;
                case "swing4charge": anm_swing4charge(); break;
                case "swingdash": anm_swingdash(); break;
                case "itemhammerair": anm_itemhammerair(); break;
                case "itemhammermove": anm_itemhammermove(); break;
                case "itemhammerwait": anm_itemhammerwait(); break;
                case "swing4bat": anm_swing4bat(); break;
                case "itemscrew": anm_itemscrew(); break;
                case "itemscrewfall": anm_itemscrewfall(); break;
                case "itemdragoonget": anm_itemdragoonget(); break;
                case "itemdragoonride": anm_itemdragoonride(); break;
                case "itemlegsjumpsquat": anm_itemlegsjumpsquat(); break;
                case "itemlegslanding": anm_itemlegslanding(); break;
                case "itemlegswalkb": anm_itemlegswalkb(); break;
                case "itemlegswalkf": anm_itemlegswalkf(); break;
                case "itemshoot": anm_itemshoot(); break;
                case "itemshootair": anm_itemshootair(); break;
                case "itemshootairloop": anm_itemshootairloop(); break;
                case "itemshootloop": anm_itemshootloop(); break;
                case "itemshootloopupper": anm_itemshootloopupper(); break;
                case "itemshootupper": anm_itemshootupper(); break;
                case "itemscopeairend": anm_itemscopeairend(); break;
                case "itemscopeairfire": anm_itemscopeairfire(); break;
                case "itemscopeairrapid": anm_itemscopeairrapid(); break;
                case "itemscopeairstart": anm_itemscopeairstart(); break;
                case "itemscopeend": anm_itemscopeend(); break;
                case "itemscopeendupper": anm_itemscopeendupper(); break;
                case "itemscopefall": anm_itemscopefall(); break;
                case "itemscopefire": anm_itemscopefire(); break;
                case "itemscopefireupper": anm_itemscopefireupper(); break;
                case "itemscoperapid": anm_itemscoperapid(); break;
                case "itemscoperapidupper": anm_itemscoperapidupper(); break;
                case "itemscopestart": anm_itemscopestart(); break;
                case "itemscopestartupper": anm_itemscopestartupper(); break;
                case "itemscopewait": anm_itemscopewait(); break;
                case "itemscopewaitupper": anm_itemscopewaitupper(); break;
                case "itemassist": anm_itemassist(); break;
                case "gekikarawait": anm_gekikarawait(); break;
                case "gekikarawaitface": anm_gekikarawaitface(); break;
                case "itemgrasspull": anm_itemgrasspull(); break;
                case "itemgenesisairend": anm_itemgenesisairend(); break;
                case "itemgenesisairfire": anm_itemgenesisairfire(); break;
                case "itemgenesisairloop": anm_itemgenesisairloop(); break;
                case "itemgenesisend": anm_itemgenesisend(); break;
                case "itemgenesisfall": anm_itemgenesisfall(); break;
                case "itemgenesisfire": anm_itemgenesisfire(); break;
                case "itemgenesisloop": anm_itemgenesisloop(); break;
                case "itemgenesisturn": anm_itemgenesisturn(); break;
                case "itemgenesiswait": anm_itemgenesiswait(); break;
                case "itemgenesiswaitupper": anm_itemgenesiswaitupper(); break;
                case "swim": anm_swim(); break;
                case "swimend": anm_swimend(); break;
                case "swimf": anm_swimf(); break;
                case "swimrise": anm_swimrise(); break;
                case "swimturn": anm_swimturn(); break;
                case "swimup": anm_swimup(); break;
                case "swimupdamage": anm_swimupdamage(); break;
                case "swimdrown": anm_swimdrown(); break;
                case "swimdrownout": anm_swimdrownout(); break;
                case "entryl": anm_entryl(); break;
                case "entryr": anm_entryr(); break;
                case "appealhil": anm_appealhil(); break;
                case "appealhir": anm_appealhir(); break;
                case "appeallwr": anm_appeallwr(); break;
                case "appealsr": anm_appealsr(); break;
                case "lose": anm_lose(); break;
                case "win1_us_en": anm_win1_us_en(); break;
                case "win1wait_us_en": anm_win1wait_us_en(); break;
                case "win2_us_en": anm_win2_us_en(); break;
                case "win2a_us_en": anm_win2a_us_en(); break;
                case "win2await_us_en": anm_win2await_us_en(); break;
                case "win2b_us_en": anm_win2b_us_en(); break;
                case "win2bwait_us_en": anm_win2bwait_us_en(); break;
                case "win2wait_us_en": anm_win2wait_us_en(); break;
                case "win3_us_en": anm_win3_us_en(); break;
                case "win3a_us_en": anm_win3a_us_en(); break;
                case "win3await_us_en": anm_win3await_us_en(); break;
                case "win3b_us_en": anm_win3b_us_en(); break;
                case "win3bwait_us_en": anm_win3bwait_us_en(); break;
                case "win3wait_us_en": anm_win3wait_us_en(); break;
                case "laddercatchairl": anm_laddercatchairl(); break;
                case "laddercatchairr": anm_laddercatchairr(); break;
                case "laddercatchendl": anm_laddercatchendl(); break;
                case "laddercatchendr": anm_laddercatchendr(); break;
                case "laddercatchl": anm_laddercatchl(); break;
                case "laddercatchr": anm_laddercatchr(); break;
                case "ladderdown": anm_ladderdown(); break;
                case "ladderup": anm_ladderup(); break;
                case "ladderwait": anm_ladderwait(); break;
                case "hair": anm_hair(); break;
                case "share": anm_share(); break;
                case "share_cliff": anm_share_cliff(); break;
                case "share_finish": anm_share_finish(); break;
                case "share_sleep": anm_share_sleep(); break;
                case "wait2": anm_wait2(); break;
                case "shieldguard": anm_shieldguard(); break;
                case "attacks3s": anm_attacks3s(); break;
                case "specialairn1": anm_specialairn1(); break;
                case "specialairn2": anm_specialairn2(); break;
                case "specialairn3": anm_specialairn3(); break;
                case "specialairncancel": anm_specialairncancel(); break;
                case "specialairnhold": anm_specialairnhold(); break;
                case "specialairnstart": anm_specialairnstart(); break;
                case "specialn1": anm_specialn1(); break;
                case "specialn2": anm_specialn2(); break;
                case "specialn3": anm_specialn3(); break;
                case "specialncancel": anm_specialncancel(); break;
                case "specialnhold": anm_specialnhold(); break;
                case "specialnstart": anm_specialnstart(); break;
                case "specialairs1": anm_specialairs1(); break;
                case "specialairs2": anm_specialairs2(); break;
                case "specialairs3": anm_specialairs3(); break;
                case "specialairs32": anm_specialairs32(); break;
                case "specialairshold": anm_specialairshold(); break;
                case "specialairsstart": anm_specialairsstart(); break;
                case "specials1": anm_specials1(); break;
                case "specials2": anm_specials2(); break;
                case "specials3": anm_specials3(); break;
                case "specials32": anm_specials32(); break;
                case "specialshold": anm_specialshold(); break;
                case "specialsstart": anm_specialsstart(); break;
                case "specialairhi1": anm_specialairhi1(); break;
                case "specialairhi2": anm_specialairhi2(); break;
                case "specialairhi3": anm_specialairhi3(); break;
                case "specialairhiempty": anm_specialairhiempty(); break;
                case "specialairhihold": anm_specialairhihold(); break;
                case "specialairhistart": anm_specialairhistart(); break;
                case "specialhi1": anm_specialhi1(); break;
                case "specialhi2": anm_specialhi2(); break;
                case "specialhi3": anm_specialhi3(); break;
                case "specialhiempty": anm_specialhiempty(); break;
                case "specialhihold": anm_specialhihold(); break;
                case "specialhistart": anm_specialhistart(); break;
                case "specialairlwcancel": anm_specialairlwcancel(); break;
                case "specialairlwfail": anm_specialairlwfail(); break;
                case "specialairlwselect": anm_specialairlwselect(); break;
                case "specialairlwselect2": anm_specialairlwselect2(); break;
                case "specialairlwskill1": anm_specialairlwskill1(); break;
                case "specialairlwskill2": anm_specialairlwskill2(); break;
                case "specialairlwskill3": anm_specialairlwskill3(); break;
                case "specialairlwskill4": anm_specialairlwskill4(); break;
                case "specialairlwspell1": anm_specialairlwspell1(); break;
                case "specialairlwspell10end": anm_specialairlwspell10end(); break;
                case "specialairlwspell10loop": anm_specialairlwspell10loop(); break;
                case "specialairlwspell10start": anm_specialairlwspell10start(); break;
                case "specialairlwspell2": anm_specialairlwspell2(); break;
                case "specialairlwspell3": anm_specialairlwspell3(); break;
                case "specialairlwspell4": anm_specialairlwspell4(); break;
                case "specialairlwspell5": anm_specialairlwspell5(); break;
                case "specialairlwspell6": anm_specialairlwspell6(); break;
                case "specialairlwspell7": anm_specialairlwspell7(); break;
                case "specialairlwspell8": anm_specialairlwspell8(); break;
                case "specialairlwspell9start": anm_specialairlwspell9start(); break;
                case "specialairlwstart": anm_specialairlwstart(); break;
                case "speciallwcancel": anm_speciallwcancel(); break;
                case "speciallwfail": anm_speciallwfail(); break;
                case "speciallwlanding": anm_speciallwlanding(); break;
                case "speciallwselect": anm_speciallwselect(); break;
                case "speciallwselect2": anm_speciallwselect2(); break;
                case "speciallwskill1": anm_speciallwskill1(); break;
                case "speciallwskill2": anm_speciallwskill2(); break;
                case "speciallwskill3": anm_speciallwskill3(); break;
                case "speciallwskill4": anm_speciallwskill4(); break;
                case "speciallwspell1": anm_speciallwspell1(); break;
                case "speciallwspell10end": anm_speciallwspell10end(); break;
                case "speciallwspell10loop": anm_speciallwspell10loop(); break;
                case "speciallwspell10start": anm_speciallwspell10start(); break;
                case "speciallwspell2": anm_speciallwspell2(); break;
                case "speciallwspell3": anm_speciallwspell3(); break;
                case "speciallwspell4": anm_speciallwspell4(); break;
                case "speciallwspell5": anm_speciallwspell5(); break;
                case "speciallwspell6": anm_speciallwspell6(); break;
                case "speciallwspell7": anm_speciallwspell7(); break;
                case "speciallwspell8": anm_speciallwspell8(); break;
                case "speciallwspell9end": anm_speciallwspell9end(); break;
                case "speciallwspell9hi": anm_speciallwspell9hi(); break;
                case "speciallwspell9lw": anm_speciallwspell9lw(); break;
                case "speciallwspell9start": anm_speciallwspell9start(); break;
                case "speciallwstart": anm_speciallwstart(); break;
                case "finalairend": anm_finalairend(); break;
                case "finalairstart": anm_finalairstart(); break;
                case "finalend": anm_finalend(); break;
                case "finalstart": anm_finalstart(); break;
                case "visualscene01": anm_visualscene01(); break;
                case "appeallwl": anm_appeallwl(); break;
                case "appealsl": anm_appealsl(); break;
                case "win1": anm_win1(); break;
                case "win1wait": anm_win1wait(); break;
                case "win2": anm_win2(); break;
                case "win2wait": anm_win2wait(); break;
                case "win3": anm_win3(); break;
                case "win3wait": anm_win3wait(); break;
                case "runstart": anm_runstart(); break;
                case "jumpaerialf1": anm_jumpaerialf1(); break;
                case "jumpaerialf2": anm_jumpaerialf2(); break;
                case "attacks3hi": anm_attacks3hi(); break;
                case "attacks3lw": anm_attacks3lw(); break;
                case "specialairnend": anm_specialairnend(); break;
                case "specialairnfire": anm_specialairnfire(); break;
                case "specialairnfire2": anm_specialairnfire2(); break;
                case "specialairnfire3": anm_specialairnfire3(); break;
                case "specialairnturn": anm_specialairnturn(); break;
                case "specialnend": anm_specialnend(); break;
                case "specialnfall": anm_specialnfall(); break;
                case "specialnfire": anm_specialnfire(); break;
                case "specialnfire2": anm_specialnfire2(); break;
                case "specialnjump": anm_specialnjump(); break;
                case "specialnjumpaerialf1": anm_specialnjumpaerialf1(); break;
                case "specialnturn": anm_specialnturn(); break;
                case "specialnupperfire": anm_specialnupperfire(); break;
                case "specialnupperwait": anm_specialnupperwait(); break;
                case "specialnwait": anm_specialnwait(); break;
                case "specialairsdash": anm_specialairsdash(); break;
                case "specialairsend": anm_specialairsend(); break;
                case "specialairsfail": anm_specialairsfail(); break;
                case "specialairswall": anm_specialairswall(); break;
                case "specialsdash": anm_specialsdash(); break;
                case "specialsend": anm_specialsend(); break;
                case "specialsfail": anm_specialsfail(); break;
                case "specialswall": anm_specialswall(); break;
                case "visualscene02": anm_visualscene02(); break;
                case "visualscene03": anm_visualscene03(); break;
                case "visualscene04": anm_visualscene04(); break;
                case "specialairn": anm_specialairn(); break;
                case "specialn": anm_specialn(); break;
                case "specialairs": anm_specialairs(); break;
                case "specialhicapture": anm_specialhicapture(); break;
                case "specialhicatch": anm_specialhicatch(); break;
                case "specialhidxcapture": anm_specialhidxcapture(); break;
                case "specialhigirlcapture": anm_specialhigirlcapture(); break;
                case "specialhithrow": anm_specialhithrow(); break;
                case "specialairlwend": anm_specialairlwend(); break;
                case "specialairlwendair": anm_specialairlwendair(); break;
                case "speciallwend": anm_speciallwend(); break;
                case "speciallwendair": anm_speciallwendair(); break;
                case "speciallwwallhit": anm_speciallwwallhit(); break;
                case "finalairridel": anm_finalairridel(); break;
                case "finalairrider": anm_finalairrider(); break;
                case "finalridel": anm_finalridel(); break;
                case "finalrider": anm_finalrider(); break;
                case "specialairnloop": anm_specialairnloop(); break;
                case "specialnloop": anm_specialnloop(); break;
                case "specialairs2hi": anm_specialairs2hi(); break;
                case "specialairs2lw": anm_specialairs2lw(); break;
                case "specialairs3hi": anm_specialairs3hi(); break;
                case "specialairs3lw": anm_specialairs3lw(); break;
                case "specialairs3s": anm_specialairs3s(); break;
                case "specialairs4hi": anm_specialairs4hi(); break;
                case "specialairs4lw": anm_specialairs4lw(); break;
                case "specialairs4s": anm_specialairs4s(); break;
                case "specials2hi": anm_specials2hi(); break;
                case "specials2lw": anm_specials2lw(); break;
                case "specials3hi": anm_specials3hi(); break;
                case "specials3lw": anm_specials3lw(); break;
                case "specials3s": anm_specials3s(); break;
                case "specials4hi": anm_specials4hi(); break;
                case "specials4lw": anm_specials4lw(); break;
                case "specials4s": anm_specials4s(); break;
                case "specialhi4": anm_specialhi4(); break;
                case "specialairlwhit": anm_specialairlwhit(); break;
                case "speciallwhit": anm_speciallwhit(); break;
                case "finalairattack": anm_finalairattack(); break;
                case "finalairdashend": anm_finalairdashend(); break;
                case "finalattack": anm_finalattack(); break;
                case "finaldash": anm_finaldash(); break;
                case "finaldashend": anm_finaldashend(); break;
                case "downspotu": anm_downspotu(); break;
                case "win1a_us_en": anm_win1a_us_en(); break;
                case "win1await_us_en": anm_win1await_us_en(); break;
                case "win1b_us_en": anm_win1b_us_en(); break;
                case "win1bwait_us_en": anm_win1bwait_us_en(); break;
                case "specialhifall": anm_specialhifall(); break;
                case "specialhifallend": anm_specialhifallend(); break;
                case "specialhilanding": anm_specialhilanding(); break;
                case "specialairlwjumpcancel": anm_specialairlwjumpcancel(); break;
                case "specialairlwlanding": anm_specialairlwlanding(); break;
                case "specialairlwloop": anm_specialairlwloop(); break;
                case "speciallwloop": anm_speciallwloop(); break;
                case "finalairhit": anm_finalairhit(); break;
                case "finalfall": anm_finalfall(); break;
                case "finalhit": anm_finalhit(); break;
                case "finalmove": anm_finalmove(); break;
                case "specialairnhit": anm_specialairnhit(); break;
                case "specialnhit": anm_specialnhit(); break;
                case "specialsjump": anm_specialsjump(); break;
                case "specialairhiend": anm_specialairhiend(); break;
                case "specialhiopen": anm_specialhiopen(); break;
                case "fuwafuwa": anm_fuwafuwa(); break;
                case "fuwafuwastart": anm_fuwafuwastart(); break;
                case "jumpaerialf3": anm_jumpaerialf3(); break;
                case "jumpaerialf4": anm_jumpaerialf4(); break;
                case "specialairnbomb": anm_specialairnbomb(); break;
                case "specialairneat": anm_specialairneat(); break;
                case "specialairneatjump1": anm_specialairneatjump1(); break;
                case "specialairneatjump2": anm_specialairneatjump2(); break;
                case "specialairnfood": anm_specialairnfood(); break;
                case "specialairnlarge": anm_specialairnlarge(); break;
                case "specialairnspit": anm_specialairnspit(); break;
                case "specialairnswallow": anm_specialairnswallow(); break;
                case "specialnbomb": anm_specialnbomb(); break;
                case "specialneat": anm_specialneat(); break;
                case "specialneatfall": anm_specialneatfall(); break;
                case "specialneatlanding": anm_specialneatlanding(); break;
                case "specialneatturn": anm_specialneatturn(); break;
                case "specialneatwait": anm_specialneatwait(); break;
                case "specialneatwalkfast": anm_specialneatwalkfast(); break;
                case "specialneatwalkmiddle": anm_specialneatwalkmiddle(); break;
                case "specialneatwalkslow": anm_specialneatwalkslow(); break;
                case "specialnfood": anm_specialnfood(); break;
                case "specialnlarge": anm_specialnlarge(); break;
                case "specialnspit": anm_specialnspit(); break;
                case "specialnswallow": anm_specialnswallow(); break;
                case "specialairsget": anm_specialairsget(); break;
                case "specialsget": anm_specialsget(); break;
                case "specialairhiturnl": anm_specialairhiturnl(); break;
                case "specialairhiturnr": anm_specialairhiturnr(); break;
                case "specialhifailure": anm_specialhifailure(); break;
                case "specialhihit": anm_specialhihit(); break;
                case "specialhijump": anm_specialhijump(); break;
                case "specialhilandingl": anm_specialhilandingl(); break;
                case "specialhilandingr": anm_specialhilandingr(); break;
                case "specialhiloop": anm_specialhiloop(); break;
                case "specialhistartl": anm_specialhistartl(); break;
                case "specialhistartr": anm_specialhistartr(); break;
                case "specialairlwmax": anm_specialairlwmax(); break;
                case "speciallwfall": anm_speciallwfall(); break;
                case "speciallwhold": anm_speciallwhold(); break;
                case "speciallwholdmax": anm_speciallwholdmax(); break;
                case "speciallwjump": anm_speciallwjump(); break;
                case "speciallwjumpsquat": anm_speciallwjumpsquat(); break;
                case "speciallwmax": anm_speciallwmax(); break;
                case "speciallwturn": anm_speciallwturn(); break;
                case "speciallwwalk": anm_speciallwwalk(); break;
                case "finalvisualscene02": anm_finalvisualscene02(); break;
                case "finalvisualscene03": anm_finalvisualscene03(); break;
                case "squatb": anm_squatb(); break;
                case "squatf": anm_squatf(); break;
                case "specialairnblow": anm_specialairnblow(); break;
                case "specialairncharge": anm_specialairncharge(); break;
                case "specialairndanger": anm_specialairndanger(); break;
                case "specialairnshoot": anm_specialairnshoot(); break;
                case "specialnblow": anm_specialnblow(); break;
                case "specialncharge": anm_specialncharge(); break;
                case "specialndanger": anm_specialndanger(); break;
                case "specialnshoot": anm_specialnshoot(); break;
                case "specialairsfall": anm_specialairsfall(); break;
                case "specialairsjump": anm_specialairsjump(); break;
                case "specialairskick": anm_specialairskick(); break;
                case "specialskicklanding": anm_specialskicklanding(); break;
                case "specialslanding": anm_specialslanding(); break;
                case "specialsstick": anm_specialsstick(); break;
                case "specialsstickattack": anm_specialsstickattack(); break;
                case "specialsstickattack2": anm_specialsstickattack2(); break;
                case "specialsstickjump": anm_specialsstickjump(); break;
                case "specialsstickjump2": anm_specialsstickjump2(); break;
                case "specialairhicharge": anm_specialairhicharge(); break;
                case "specialairhichargeb": anm_specialairhichargeb(); break;
                case "specialairhichargef": anm_specialairhichargef(); break;
                case "specialairhidamage": anm_specialairhidamage(); break;
                case "specialairhijdamage": anm_specialairhijdamage(); break;
                case "specialairhijump": anm_specialairhijump(); break;
                case "specialhicharge": anm_specialhicharge(); break;
                case "specialhichargeb": anm_specialhichargeb(); break;
                case "specialhichargef": anm_specialhichargef(); break;
                case "specialairlwmiss": anm_specialairlwmiss(); break;
                case "speciallwmiss": anm_speciallwmiss(); break;
                case "finalcharge": anm_finalcharge(); break;
                case "finalfinishhi": anm_finalfinishhi(); break;
                case "finalfinishlw": anm_finalfinishlw(); break;
                case "finalfinishs": anm_finalfinishs(); break;
                case "finalhi": anm_finalhi(); break;
                case "finallw": anm_finallw(); break;
                case "finals": anm_finals(); break;
                case "finalstarthi": anm_finalstarthi(); break;
                case "specialsdxstickattackcapture": anm_specialsdxstickattackcapture(); break;
                case "specialsdxstickcapture": anm_specialsdxstickcapture(); break;
                case "specialsdxstickjumpcapture": anm_specialsdxstickjumpcapture(); break;
                case "specialsgirlstickattackcapture": anm_specialsgirlstickattackcapture(); break;
                case "specialsgirlstickcapture": anm_specialsgirlstickcapture(); break;
                case "specialsgirlstickjumpcapture": anm_specialsgirlstickjumpcapture(); break;
                case "specialsstickattackcapture": anm_specialsstickattackcapture(); break;
                case "specialsstickcapture": anm_specialsstickcapture(); break;
                case "specialsstickjumpcapture": anm_specialsstickjumpcapture(); break;
                case "walkbrakelb": anm_walkbrakelb(); break;
                case "walkbrakerb": anm_walkbrakerb(); break;
                case "walkfastb": anm_walkfastb(); break;
                case "walkmiddleb": anm_walkmiddleb(); break;
                case "walkslowb": anm_walkslowb(); break;
                case "dashb": anm_dashb(); break;
                case "dashbrun": anm_dashbrun(); break;
                case "walkfalllb": anm_walkfalllb(); break;
                case "walkfallrb": anm_walkfallrb(); break;
                case "specialairsbend": anm_specialairsbend(); break;
                case "specialairsbstart": anm_specialairsbstart(); break;
                case "specialairsfend": anm_specialairsfend(); break;
                case "specialairsfstart": anm_specialairsfstart(); break;
                case "specialsbend": anm_specialsbend(); break;
                case "specialsbs": anm_specialsbs(); break;
                case "specialsbstart": anm_specialsbstart(); break;
                case "specialsbw": anm_specialsbw(); break;
                case "specialsf": anm_specialsf(); break;
                case "specialsfend": anm_specialsfend(); break;
                case "specialsfstart": anm_specialsfstart(); break;
                case "specialairlwrise": anm_specialairlwrise(); break;
                case "specialairlwrisew": anm_specialairlwrisew(); break;
                case "superspecial1": anm_superspecial1(); break;
                case "superspecial2": anm_superspecial2(); break;
                case "superspecial2start": anm_superspecial2start(); break;
                case "visualscene05": anm_visualscene05(); break;
                case "capshadow": anm_capshadow(); break;
                case "specialairnjumpcancel": anm_specialairnjumpcancel(); break;
                case "throwfb": anm_throwfb(); break;
                case "throwff": anm_throwff(); break;
                case "throwffall": anm_throwffall(); break;
                case "throwfhi": anm_throwfhi(); break;
                case "throwfjump": anm_throwfjump(); break;
                case "throwfjumpsquat": anm_throwfjumpsquat(); break;
                case "throwflanding": anm_throwflanding(); break;
                case "throwflw": anm_throwflw(); break;
                case "throwfturn": anm_throwfturn(); break;
                case "throwfwait": anm_throwfwait(); break;
                case "throwfwalkfast": anm_throwfwalkfast(); break;
                case "throwfwalkmiddle": anm_throwfwalkmiddle(); break;
                case "throwfwalkslow": anm_throwfwalkslow(); break;
                case "thrownbigfb": anm_thrownbigfb(); break;
                case "thrownbigff": anm_thrownbigff(); break;
                case "throwndxfb": anm_throwndxfb(); break;
                case "throwndxff": anm_throwndxff(); break;
                case "throwndxfhi": anm_throwndxfhi(); break;
                case "throwndxflw": anm_throwndxflw(); break;
                case "throwndxzitabata": anm_throwndxzitabata(); break;
                case "thrownfb": anm_thrownfb(); break;
                case "thrownff": anm_thrownff(); break;
                case "thrownfhi": anm_thrownfhi(); break;
                case "thrownflw": anm_thrownflw(); break;
                case "throwngirlfb": anm_throwngirlfb(); break;
                case "throwngirlff": anm_throwngirlff(); break;
                case "throwngirlfhi": anm_throwngirlfhi(); break;
                case "throwngirlflw": anm_throwngirlflw(); break;
                case "throwngirlzitabata": anm_throwngirlzitabata(); break;
                case "thrownzitabata": anm_thrownzitabata(); break;
                case "heavyfall": anm_heavyfall(); break;
                case "heavyjump": anm_heavyjump(); break;
                case "heavyjumpsquat": anm_heavyjumpsquat(); break;
                case "heavylanding": anm_heavylanding(); break;
                case "heavyturn": anm_heavyturn(); break;
                case "heavywait": anm_heavywait(); break;
                case "heavywalkfast": anm_heavywalkfast(); break;
                case "heavywalkmiddle": anm_heavywalkmiddle(); break;
                case "heavywalkslow": anm_heavywalkslow(); break;
                case "share_specialnmax": anm_share_specialnmax(); break;
                case "specialhiend": anm_specialhiend(); break;
                case "finalairready": anm_finalairready(); break;
                case "finalready": anm_finalready(); break;
                case "itemrocketbelt": anm_itemrocketbelt(); break;
                case "closingear": anm_closingear(); break;
                case "specialsfalllanding": anm_specialsfalllanding(); break;
                case "specialhibound": anm_specialhibound(); break;
                case "specialhiholdair": anm_specialhiholdair(); break;
                case "specialairlwr": anm_specialairlwr(); break;
                case "speciallwr": anm_speciallwr(); break;
                case "finalairlockon": anm_finalairlockon(); break;
                case "finallockon": anm_finallockon(); break;
                case "finalvisualscene": anm_finalvisualscene(); break;
                case "appealsendl": anm_appealsendl(); break;
                case "appealsendr": anm_appealsendr(); break;
                case "appealsstartl": anm_appealsstartl(); break;
                case "appealsstartr": anm_appealsstartr(); break;
                case "specialairlwendl": anm_specialairlwendl(); break;
                case "specialairlwhitl": anm_specialairlwhitl(); break;
                case "specialairlwloopl": anm_specialairlwloopl(); break;
                case "specialairlwstartl": anm_specialairlwstartl(); break;
                case "speciallwendl": anm_speciallwendl(); break;
                case "speciallwhitl": anm_speciallwhitl(); break;
                case "speciallwloopl": anm_speciallwloopl(); break;
                case "speciallwstartl": anm_speciallwstartl(); break;
                case "attackhi3l": anm_attackhi3l(); break;
                case "attackhi4r": anm_attackhi4r(); break;
                case "attackhi4rcharge": anm_attackhi4rcharge(); break;
                case "specialairsl": anm_specialairsl(); break;
                case "specialsl": anm_specialsl(); break;
                case "specialhiclose": anm_specialhiclose(); break;
                case "specialairlwcatch": anm_specialairlwcatch(); break;
                case "specialairlwshoot": anm_specialairlwshoot(); break;
                case "speciallwcatch": anm_speciallwcatch(); break;
                case "speciallwshoot": anm_speciallwshoot(); break;
                case "specialairscatch": anm_specialairscatch(); break;
                case "ganonspecialhicapture": anm_ganonspecialhicapture(); break;
                case "ganonspecialhidxcapture": anm_ganonspecialhidxcapture(); break;
                case "ganonspecialhigirlcapture": anm_ganonspecialhigirlcapture(); break;
                case "specialairscapture": anm_specialairscapture(); break;
                case "specialairscatchcapture": anm_specialairscatchcapture(); break;
                case "specialairsdxcapture": anm_specialairsdxcapture(); break;
                case "specialairsdxcatchcapture": anm_specialairsdxcatchcapture(); break;
                case "specialairsdxfallcapture": anm_specialairsdxfallcapture(); break;
                case "specialairsfallcapture": anm_specialairsfallcapture(); break;
                case "specialairsgirlcapture": anm_specialairsgirlcapture(); break;
                case "specialairsgirlcatchcapture": anm_specialairsgirlcatchcapture(); break;
                case "specialairsgirlfallcapture": anm_specialairsgirlfallcapture(); break;
                case "specialscapture": anm_specialscapture(); break;
                case "specialsdxcapture": anm_specialsdxcapture(); break;
                case "specialsgirlcapture": anm_specialsgirlcapture(); break;
                case "bossentry": anm_bossentry(); break;
                case "bossentry2": anm_bossentry2(); break;
                case "attack13hit": anm_attack13hit(); break;
                case "attackdashhit": anm_attackdashhit(); break;
                case "attacks4shit": anm_attacks4shit(); break;
                case "attackhi4hit": anm_attackhi4hit(); break;
                case "attacklw4hit": anm_attacklw4hit(); break;
                case "gaogaenspecialsdamage": anm_gaogaenspecialsdamage(); break;
                case "gaogaenspecialsdamagebig": anm_gaogaenspecialsdamagebig(); break;
                case "gaogaenspecialsdamagedx": anm_gaogaenspecialsdamagedx(); break;
                case "gaogaenspecialsdamagegirl": anm_gaogaenspecialsdamagegirl(); break;
                case "gaogaenspecialsfailure": anm_gaogaenspecialsfailure(); break;
                case "gaogaenspecialsfailurebig": anm_gaogaenspecialsfailurebig(); break;
                case "gaogaenspecialsfailuredx": anm_gaogaenspecialsfailuredx(); break;
                case "gaogaenspecialsfailuregirl": anm_gaogaenspecialsfailuregirl(); break;
                case "gaogaenspecialsthrown": anm_gaogaenspecialsthrown(); break;
                case "gaogaenspecialsthrownbig": anm_gaogaenspecialsthrownbig(); break;
                case "gaogaenspecialsthrowndx": anm_gaogaenspecialsthrowndx(); break;
                case "gaogaenspecialsthrowngirl": anm_gaogaenspecialsthrowngirl(); break;
                case "specialairsfailure": anm_specialairsfailure(); break;
                case "specialairslariat": anm_specialairslariat(); break;
                case "specialairsshoulder": anm_specialairsshoulder(); break;
                case "specialairsthrow": anm_specialairsthrow(); break;
                case "specialsfailure": anm_specialsfailure(); break;
                case "specialslariat": anm_specialslariat(); break;
                case "specialsshoulder": anm_specialsshoulder(); break;
                case "specialsthrow": anm_specialsthrow(); break;
                case "specialairhifall": anm_specialairhifall(); break;
                case "specialairhiloop": anm_specialairhiloop(); break;
                case "specialairhiturn": anm_specialairhiturn(); break;
                case "specialairlwturn": anm_specialairlwturn(); break;
                case "finalcatch": anm_finalcatch(); break;
                case "gaogaenthrown01": anm_gaogaenthrown01(); break;
                case "gaogaenthrown01big": anm_gaogaenthrown01big(); break;
                case "gaogaenthrown01dx": anm_gaogaenthrown01dx(); break;
                case "gaogaenthrown01girl": anm_gaogaenthrown01girl(); break;
                case "gaogaenthrown02": anm_gaogaenthrown02(); break;
                case "gaogaenthrown02big": anm_gaogaenthrown02big(); break;
                case "gaogaenthrown02dx": anm_gaogaenthrown02dx(); break;
                case "gaogaenthrown02girl": anm_gaogaenthrown02girl(); break;
                case "gaogaenthrown03": anm_gaogaenthrown03(); break;
                case "gaogaenthrown03big": anm_gaogaenthrown03big(); break;
                case "gaogaenthrown03dx": anm_gaogaenthrown03dx(); break;
                case "gaogaenthrown03girl": anm_gaogaenthrown03girl(); break;
                case "specialairnmaxshot": anm_specialairnmaxshot(); break;
                case "specialairnshot": anm_specialairnshot(); break;
                case "specialnmaxshot": anm_specialnmaxshot(); break;
                case "specialnshot": anm_specialnshot(); break;
                case "specialairsattackb": anm_specialairsattackb(); break;
                case "specialairsattackf": anm_specialairsattackf(); break;
                case "specialairsendb": anm_specialairsendb(); break;
                case "specialairsendf": anm_specialairsendf(); break;
                case "specialsattackb": anm_specialsattackb(); break;
                case "specialsattackf": anm_specialsattackf(); break;
                case "specialsendb": anm_specialsendb(); break;
                case "specialsendf": anm_specialsendf(); break;
                case "specialairlwattack": anm_specialairlwattack(); break;
                case "speciallwattack": anm_speciallwattack(); break;
                case "speciallwbound": anm_speciallwbound(); break;
                case "finalchange": anm_finalchange(); break;
                case "finalmiss": anm_finalmiss(); break;
                case "specialsairattack": anm_specialsairattack(); break;
                case "specialsairdash": anm_specialsairdash(); break;
                case "specialsairend": anm_specialsairend(); break;
                case "specialsairhold": anm_specialsairhold(); break;
                case "specialsairstart": anm_specialsairstart(); break;
                case "specialsattack": anm_specialsattack(); break;
                case "finalairstarthit": anm_finalairstarthit(); break;
                case "finalairstarthitl": anm_finalairstarthitl(); break;
                case "finalstarthit": anm_finalstarthit(); break;
                case "finalstarthitl": anm_finalstarthitl(); break;
                case "landingfallspeciall": anm_landingfallspeciall(); break;
                case "specialairnfired": anm_specialairnfired(); break;
                case "specialairnfiren": anm_specialairnfiren(); break;
                case "specialairnfireu": anm_specialairnfireu(); break;
                case "specialnfired": anm_specialnfired(); break;
                case "specialnfiren": anm_specialnfiren(); break;
                case "specialnfireu": anm_specialnfireu(); break;
                case "specialairsjumpend": anm_specialairsjumpend(); break;
                case "specialairsrun": anm_specialairsrun(); break;
                case "specialairsstartempty": anm_specialairsstartempty(); break;
                case "specialairsstopwall": anm_specialairsstopwall(); break;
                case "specialairswalk": anm_specialairswalk(); break;
                case "specialairswalkempty": anm_specialairswalkempty(); break;
                case "specialsjumpend": anm_specialsjumpend(); break;
                case "specialsrun": anm_specialsrun(); break;
                case "specialsrunturn": anm_specialsrunturn(); break;
                case "specialsstartempty": anm_specialsstartempty(); break;
                case "specialsstopwall": anm_specialsstopwall(); break;
                case "specialswalk": anm_specialswalk(); break;
                case "specialswalkempty": anm_specialswalkempty(); break;
                case "specialswalkturn": anm_specialswalkturn(); break;
                case "specialairhistartl": anm_specialairhistartl(); break;
                case "specialairhistartr": anm_specialairhistartr(); break;
                case "specialhijumpl": anm_specialhijumpl(); break;
                case "specialhijumpr": anm_specialhijumpr(); break;
                case "specialhistopceill": anm_specialhistopceill(); break;
                case "specialhistopceilr": anm_specialhistopceilr(); break;
                case "specialhitopl": anm_specialhitopl(); break;
                case "specialhitopr": anm_specialhitopr(); break;
                case "specialairlwempty": anm_specialairlwempty(); break;
                case "specialairlwmiddle": anm_specialairlwmiddle(); break;
                case "specialairlwmin": anm_specialairlwmin(); break;
                case "speciallwempty": anm_speciallwempty(); break;
                case "speciallwmiddle": anm_speciallwmiddle(); break;
                case "speciallwmin": anm_speciallwmin(); break;
                case "specialinkcharge": anm_specialinkcharge(); break;
                case "specialinkchargeend": anm_specialinkchargeend(); break;
                case "specialinkchargestart": anm_specialinkchargestart(); break;
                case "red": anm_red(); break;
                case "yellow": anm_yellow(); break;
                case "specialairn1doy": anm_specialairn1doy(); break;
                case "specialairn2doy": anm_specialairn2doy(); break;
                case "specialairn3doy": anm_specialairn3doy(); break;
                case "specialairndown": anm_specialairndown(); break;
                case "specialairndownend": anm_specialairndownend(); break;
                case "specialairndownstart": anm_specialairndownstart(); break;
                case "specialairnescapeb": anm_specialairnescapeb(); break;
                case "specialairnescapebdoy": anm_specialairnescapebdoy(); break;
                case "specialairnescapef": anm_specialairnescapef(); break;
                case "specialairnescapefdoy": anm_specialairnescapefdoy(); break;
                case "specialairnrandom": anm_specialairnrandom(); break;
                case "specialairnrandomend": anm_specialairnrandomend(); break;
                case "specialairnrandomstart": anm_specialairnrandomstart(); break;
                case "specialn1doy": anm_specialn1doy(); break;
                case "specialn2doy": anm_specialn2doy(); break;
                case "specialn3doy": anm_specialn3doy(); break;
                case "specialndownlanding": anm_specialndownlanding(); break;
                case "specialnescapeb": anm_specialnescapeb(); break;
                case "specialnescapebdoy": anm_specialnescapebdoy(); break;
                case "specialnescapef": anm_specialnescapef(); break;
                case "specialnescapefdoy": anm_specialnescapefdoy(); break;
                case "specialnjumplanding": anm_specialnjumplanding(); break;
                case "specialnlanding": anm_specialnlanding(); break;
                case "specialnrandomlanding": anm_specialnrandomlanding(); break;
                case "specialairhib": anm_specialairhib(); break;
                case "specialairhicatch": anm_specialairhicatch(); break;
                case "specialairhicut": anm_specialairhicut(); break;
                case "specialairhiendb": anm_specialairhiendb(); break;
                case "specialairhiendf": anm_specialairhiendf(); break;
                case "specialairhif": anm_specialairhif(); break;
                case "specialairhiitem": anm_specialairhiitem(); break;
                case "specialairhipull": anm_specialairhipull(); break;
                case "specialairhipull2": anm_specialairhipull2(); break;
                case "specialairhithrow": anm_specialairhithrow(); break;
                case "specialhicut": anm_specialhicut(); break;
                case "specialhiitem": anm_specialhiitem(); break;
                case "specialhipull": anm_specialhipull(); break;
                case "specialhipull2": anm_specialhipull2(); break;
                case "specialairlw1": anm_specialairlw1(); break;
                case "specialairlw2": anm_specialairlw2(); break;
                case "specialairlwdamage": anm_specialairlwdamage(); break;
                case "speciallw1": anm_speciallw1(); break;
                case "speciallw2": anm_speciallw2(); break;
                case "speciallwdamage": anm_speciallwdamage(); break;
                case "finalairdash": anm_finalairdash(); break;
                case "finalairturn": anm_finalairturn(); break;
                case "finalturn": anm_finalturn(); break;
                case "specialhipulled": anm_specialhipulled(); break;
                case "specialhipulledbig": anm_specialhipulledbig(); break;
                case "specialhipulleddx": anm_specialhipulleddx(); break;
                case "specialhipulledgirl": anm_specialhipulledgirl(); break;
                case "specialhithrown": anm_specialhithrown(); break;
                case "specialhithrownbig": anm_specialhithrownbig(); break;
                case "specialhithrowndx": anm_specialhithrowndx(); break;
                case "specialhithrowngirl": anm_specialhithrowngirl(); break;
                case "aircatch": anm_aircatch(); break;
                case "aircatchhang": anm_aircatchhang(); break;
                case "aircatchhit": anm_aircatchhit(); break;
                case "aircatchhitloop": anm_aircatchhitloop(); break;
                case "aircatchpose": anm_aircatchpose(); break;
                case "win4": anm_win4(); break;
                case "win4wait": anm_win4wait(); break;
                case "specialairnend1": anm_specialairnend1(); break;
                case "specialairnend2": anm_specialairnend2(); break;
                case "specialnend1": anm_specialnend1(); break;
                case "specialnend2": anm_specialnend2(); break;
                case "specialairsattack": anm_specialairsattack(); break;
                case "specialsattacklanding": anm_specialsattacklanding(); break;
                case "specialsjumplanding": anm_specialsjumplanding(); break;
                case "specialswallattackb": anm_specialswallattackb(); break;
                case "specialswallattackblanding": anm_specialswallattackblanding(); break;
                case "specialswallattackf": anm_specialswallattackf(); break;
                case "specialswallattackflanding": anm_specialswallattackflanding(); break;
                case "specialswallend": anm_specialswallend(); break;
                case "specialswalljump": anm_specialswalljump(); break;
                case "specialairlwhitturn": anm_specialairlwhitturn(); break;
                case "speciallwhitturn": anm_speciallwhitturn(); break;
                case "uid00specialairnend2": anm_uid00specialairnend2(); break;
                case "uid00specialnend2": anm_uid00specialnend2(); break;
                case "wait1b": anm_wait1b(); break;
                case "wait1f": anm_wait1f(); break;
                case "justshield": anm_justshield(); break;
                case "attack11s": anm_attack11s(); break;
                case "attack11w": anm_attack11w(); break;
                case "attacknearw": anm_attacknearw(); break;
                case "attacks3ss": anm_attacks3ss(); break;
                case "attacks3sw": anm_attacks3sw(); break;
                case "attackhi3s": anm_attackhi3s(); break;
                case "attackhi3w": anm_attackhi3w(); break;
                case "attacklw3s": anm_attacklw3s(); break;
                case "attacklw3w": anm_attacklw3w(); break;
                case "specialairnempty": anm_specialairnempty(); break;
                case "specialnempty": anm_specialnempty(); break;
                case "specialairlwstepb": anm_specialairlwstepb(); break;
                case "specialairlwstepf": anm_specialairlwstepf(); break;
                case "speciallwstepb": anm_speciallwstepb(); break;
                case "speciallwstepf": anm_speciallwstepf(); break;
                case "final2": anm_final2(); break;
                case "final2fall": anm_final2fall(); break;
                case "final2landing": anm_final2landing(); break;
                case "finalair2": anm_finalair2(); break;
                case "finalair2end": anm_finalair2end(); break;
                case "finallanding": anm_finallanding(); break;
                case "specialcmd1": anm_specialcmd1(); break;
                case "specialcmd2": anm_specialcmd2(); break;
                case "specialcmd3": anm_specialcmd3(); break;
                case "sumi": anm_sumi(); break;
                case "jumpaerialf5": anm_jumpaerialf5(); break;
                case "squatwait2": anm_squatwait2(); break;
                case "eatfall": anm_eatfall(); break;
                case "eatjump1": anm_eatjump1(); break;
                case "eatjump2": anm_eatjump2(); break;
                case "eatlanding": anm_eatlanding(); break;
                case "eatturn": anm_eatturn(); break;
                case "eatwait": anm_eatwait(); break;
                case "eatwalkfast": anm_eatwalkfast(); break;
                case "eatwalkmiddle": anm_eatwalkmiddle(); break;
                case "eatwalkslow": anm_eatwalkslow(); break;
                case "specialndrink": anm_specialndrink(); break;
                case "specialnegg": anm_specialnegg(); break;
                case "specialairsmax": anm_specialairsmax(); break;
                case "specialsfall": anm_specialsfall(); break;
                case "specialsholdmax": anm_specialsholdmax(); break;
                case "specialsjumpsquat": anm_specialsjumpsquat(); break;
                case "specialsmax": anm_specialsmax(); break;
                case "specialsturn": anm_specialsturn(); break;
                case "specialairnbigbitten": anm_specialairnbigbitten(); break;
                case "specialairnbigbittenend": anm_specialairnbigbittenend(); break;
                case "specialairnbigbittenstart": anm_specialairnbigbittenstart(); break;
                case "specialairnbitten": anm_specialairnbitten(); break;
                case "specialairnbittenend": anm_specialairnbittenend(); break;
                case "specialairnbittenstart": anm_specialairnbittenstart(); break;
                case "specialairndxbitten": anm_specialairndxbitten(); break;
                case "specialairndxbittenend": anm_specialairndxbittenend(); break;
                case "specialairndxbittenstart": anm_specialairndxbittenstart(); break;
                case "specialairngirlbitten": anm_specialairngirlbitten(); break;
                case "specialairngirlbittenend": anm_specialairngirlbittenend(); break;
                case "specialairngirlbittenstart": anm_specialairngirlbittenstart(); break;
                case "specialnbigbitten": anm_specialnbigbitten(); break;
                case "specialnbigbittenend": anm_specialnbigbittenend(); break;
                case "specialnbigbittenstart": anm_specialnbigbittenstart(); break;
                case "specialnbitten": anm_specialnbitten(); break;
                case "specialnbittenend": anm_specialnbittenend(); break;
                case "specialnbittenstart": anm_specialnbittenstart(); break;
                case "specialndxbitten": anm_specialndxbitten(); break;
                case "specialndxbittenend": anm_specialndxbittenend(); break;
                case "specialndxbittenstart": anm_specialndxbittenstart(); break;
                case "specialngirlbitten": anm_specialngirlbitten(); break;
                case "specialngirlbittenend": anm_specialngirlbittenend(); break;
                case "specialngirlbittenstart": anm_specialngirlbittenstart(); break;
                case "itemlegsbrakeb": anm_itemlegsbrakeb(); break;
                case "itemlegsbrakef": anm_itemlegsbrakef(); break;
                case "itemlegsdashb": anm_itemlegsdashb(); break;
                case "itemlegsdashf": anm_itemlegsdashf(); break;
                case "itemlegsfastb": anm_itemlegsfastb(); break;
                case "itemlegsfastf": anm_itemlegsfastf(); break;
                case "itemlegsmiddleb": anm_itemlegsmiddleb(); break;
                case "itemlegsmiddlef": anm_itemlegsmiddlef(); break;
                case "itemlegsslowb": anm_itemlegsslowb(); break;
                case "itemlegsslowf": anm_itemlegsslowf(); break;
                case "itemlegswait": anm_itemlegswait(); break;
                case "adventurerun": anm_adventurerun(); break;
                case "specialairssquat": anm_specialairssquat(); break;
                case "specialsaircatch": anm_specialsaircatch(); break;
                case "specialscatch": anm_specialscatch(); break;
                case "specialssquat": anm_specialssquat(); break;
                case "specialsdxzitabata": anm_specialsdxzitabata(); break;
                case "specialsgirlzitabata": anm_specialsgirlzitabata(); break;
                case "specialszitabata": anm_specialszitabata(); break;
                case "death": anm_death(); break;
                case "deathair": anm_deathair(); break;
                case "appealhi": anm_appealhi(); break;
                case "appeallw": anm_appeallw(); break;
                case "appeals": anm_appeals(); break;
                case "itemhandgrip2": anm_itemhandgrip2(); break;
                case "walkbrake": anm_walkbrake(); break;
                case "specialairsspin": anm_specialairsspin(); break;
                case "specialairswallclash": anm_specialairswallclash(); break;
                case "specialscliffjump": anm_specialscliffjump(); break;
                case "specialsspin": anm_specialsspin(); break;
                case "specialswallclash": anm_specialswallclash(); break;
                case "specialhiattacklanding": anm_specialhiattacklanding(); break;
                case "specialhidamageend": anm_specialhidamageend(); break;
                case "specialhijrattack": anm_specialhijrattack(); break;
                case "specialhijrdamage": anm_specialhijrdamage(); break;
                case "specialhijrescape": anm_specialhijrescape(); break;
                case "specialhijrfall": anm_specialhijrfall(); break;
                case "specialhijrrise": anm_specialhijrrise(); break;
                case "cliffcatchjr": anm_cliffcatchjr(); break;
                case "cliffwaitjr": anm_cliffwaitjr(); break;
                case "cliffattackjr": anm_cliffattackjr(); break;
                case "cliffclimbjr": anm_cliffclimbjr(); break;
                case "cliffescapejr": anm_cliffescapejr(); break;
                case "cliffjump1jr": anm_cliffjump1jr(); break;
                case "specialairnspitb": anm_specialairnspitb(); break;
                case "specialairnspitf": anm_specialairnspitf(); break;
                case "specialairnspithi": anm_specialairnspithi(); break;
                case "specialairnsuction": anm_specialairnsuction(); break;
                case "specialnspitb": anm_specialnspitb(); break;
                case "specialnspitf": anm_specialnspitf(); break;
                case "specialnspithi": anm_specialnspithi(); break;
                case "specialnsuction": anm_specialnsuction(); break;
                case "specialhiairend": anm_specialhiairend(); break;
                case "specialhiairendb": anm_specialhiairendb(); break;
                case "specialhiairendf": anm_specialhiairendf(); break;
                case "specialhib": anm_specialhib(); break;
                case "specialhif": anm_specialhif(); break;
                case "specialhifallb": anm_specialhifallb(); break;
                case "specialhifallf": anm_specialhifallf(); break;
                case "attacks4s2": anm_attacks4s2(); break;
                case "specialairlwblast": anm_specialairlwblast(); break;
                case "speciallwblast": anm_speciallwblast(); break;
                case "specialairndash": anm_specialairndash(); break;
                case "specialairndashturn": anm_specialairndashturn(); break;
                case "specialairnmaxdash": anm_specialairnmaxdash(); break;
                case "specialairnmaxdashend": anm_specialairnmaxdashend(); break;
                case "specialairnmaxdashturn": anm_specialairnmaxdashturn(); break;
                case "specialndash": anm_specialndash(); break;
                case "specialndashturn": anm_specialndashturn(); break;
                case "specialnmaxdash": anm_specialnmaxdash(); break;
                case "specialnmaxdashend": anm_specialnmaxdashend(); break;
                case "specialnmaxdashturn": anm_specialnmaxdashturn(); break;
                case "specialairsblow": anm_specialairsblow(); break;
                case "specialsblowend": anm_specialsblowend(); break;
                case "share_ko": anm_share_ko(); break;
                case "specialairnmax": anm_specialairnmax(); break;
                case "specialnmax": anm_specialnmax(); break;
                case "specialhimove": anm_specialhimove(); break;
                case "specialairappear": anm_specialairappear(); break;
                case "speciallwsplit": anm_speciallwsplit(); break;
                case "finalairreturn": anm_finalairreturn(); break;
                case "finalairreturnl": anm_finalairreturnl(); break;
                case "finalairstartl": anm_finalairstartl(); break;
                case "finalairstartr": anm_finalairstartr(); break;
                case "finalstartl": anm_finalstartl(); break;
                case "finalstartr": anm_finalstartr(); break;
                case "specialairhiattackend": anm_specialairhiattackend(); break;
                case "specialairlwhold": anm_specialairlwhold(); break;
                case "aircatchlanding": anm_aircatchlanding(); break;
                case "specialairnendhi": anm_specialairnendhi(); break;
                case "specialairnendlw": anm_specialairnendlw(); break;
                case "specialnendhi": anm_specialnendhi(); break;
                case "specialnendlw": anm_specialnendlw(); break;
                case "specialsdischarge": anm_specialsdischarge(); break;
                case "specialhidrop": anm_specialhidrop(); break;
                case "finalairfail": anm_finalairfail(); break;
                case "finalairfaill": anm_finalairfaill(); break;
                case "finalairshoot": anm_finalairshoot(); break;
                case "finalairshootready": anm_finalairshootready(); break;
                case "finalairvacuum": anm_finalairvacuum(); break;
                case "finalfail": anm_finalfail(); break;
                case "finalfaill": anm_finalfaill(); break;
                case "finalshoot": anm_finalshoot(); break;
                case "finalshootready": anm_finalshootready(); break;
                case "finalvacuum": anm_finalvacuum(); break;
                case "catchattackl": anm_catchattackl(); break;
                case "catchcutl": anm_catchcutl(); break;
                case "catchdashl": anm_catchdashl(); break;
                case "catchl": anm_catchl(); break;
                case "catchpulll": anm_catchpulll(); break;
                case "catchturnl": anm_catchturnl(); break;
                case "catchwaitl": anm_catchwaitl(); break;
                case "throwbl": anm_throwbl(); break;
                case "throwfl": anm_throwfl(); break;
                case "throwhil": anm_throwhil(); break;
                case "throwlwl": anm_throwlwl(); break;
                case "aircatchl": anm_aircatchl(); break;
                case "aircatchlandingl": anm_aircatchlandingl(); break;
                case "specialairlwheavy": anm_specialairlwheavy(); break;
                case "specialairlwlight": anm_specialairlwlight(); break;
                case "speciallwheavy": anm_speciallwheavy(); break;
                case "speciallwlight": anm_speciallwlight(); break;
                case "specialairsf": anm_specialairsf(); break;
                case "specialairhifailure": anm_specialairhifailure(); break;
                case "specialairhihit": anm_specialairhihit(); break;
                case "specialairhihitpose": anm_specialairhihitpose(); break;
                case "specialairhiovertake": anm_specialairhiovertake(); break;
                case "specialairhiwallfailure": anm_specialairhiwallfailure(); break;
                case "specialairhiwalljump": anm_specialairhiwalljump(); break;
                case "specialhihitpose": anm_specialhihitpose(); break;
                case "speciallwlanding1": anm_speciallwlanding1(); break;
                case "speciallwlanding2": anm_speciallwlanding2(); break;
                case "aircatchhang2": anm_aircatchhang2(); break;
                case "share_damage": anm_share_damage(); break;
                case "runbrake": anm_runbrake(); break;
                case "attacks3s2": anm_attacks3s2(); break;
                case "attacks3s3": anm_attacks3s3(); break;
                case "specialnspin": anm_specialnspin(); break;
                case "specialairsfinish": anm_specialairsfinish(); break;
                case "specialsdrill": anm_specialsdrill(); break;
                case "specialairlwb": anm_specialairlwb(); break;
                case "specialairlwf": anm_specialairlwf(); break;
                case "speciallwb": anm_speciallwb(); break;
                case "speciallwf": anm_speciallwf(); break;
                case "finalfinish": anm_finalfinish(); break;
                case "finalfinishl": anm_finalfinishl(); break;
                case "finalfinishr": anm_finalfinishr(); break;
                case "finaljump": anm_finaljump(); break;
                case "finalsquatl": anm_finalsquatl(); break;
                case "finalsquatr": anm_finalsquatr(); break;
                case "fear": anm_fear(); break;
                case "feardonkey": anm_feardonkey(); break;
                case "feardonkeyreverse": anm_feardonkeyreverse(); break;
                case "feardx": anm_feardx(); break;
                case "feardxreverse": anm_feardxreverse(); break;
                case "feargirl": anm_feargirl(); break;
                case "feargirlreverse": anm_feargirlreverse(); break;
                case "fearreverse": anm_fearreverse(); break;
                case "wingfold": anm_wingfold(); break;
                case "wingloop": anm_wingloop(); break;
                case "specialairn2finish": anm_specialairn2finish(); break;
                case "specialairn2finishmiss": anm_specialairn2finishmiss(); break;
                case "specialairn2miss": anm_specialairn2miss(); break;
                case "specialairn2start": anm_specialairn2start(); break;
                case "specialairn3turn": anm_specialairn3turn(); break;
                case "specialn2finish": anm_specialn2finish(); break;
                case "specialn2finishmiss": anm_specialn2finishmiss(); break;
                case "specialn2miss": anm_specialn2miss(); break;
                case "specialn2start": anm_specialn2start(); break;
                case "specialn3turn": anm_specialn3turn(); break;
                case "specialairs1start": anm_specialairs1start(); break;
                case "specialairs2end": anm_specialairs2end(); break;
                case "specialairs2start": anm_specialairs2start(); break;
                case "specialairs3catch": anm_specialairs3catch(); break;
                case "specialairs3dash": anm_specialairs3dash(); break;
                case "specialairs3fall": anm_specialairs3fall(); break;
                case "specialairs3landing": anm_specialairs3landing(); break;
                case "specials1start": anm_specials1start(); break;
                case "specials2end": anm_specials2end(); break;
                case "specials2hit": anm_specials2hit(); break;
                case "specials2hitlanding": anm_specials2hitlanding(); break;
                case "specials2start": anm_specials2start(); break;
                case "specials3dash": anm_specials3dash(); break;
                case "specials3throw": anm_specials3throw(); break;
                case "specialairhi11": anm_specialairhi11(); break;
                case "specialairhi12": anm_specialairhi12(); break;
                case "specialairhi13": anm_specialairhi13(); break;
                case "specialhi11": anm_specialhi11(); break;
                case "specialhi14": anm_specialhi14(); break;
                case "specialairlw2autoattack": anm_specialairlw2autoattack(); break;
                case "specialairlw2kick": anm_specialairlw2kick(); break;
                case "specialairlw2start": anm_specialairlw2start(); break;
                case "specialairlw3": anm_specialairlw3(); break;
                case "specialairlw3catch": anm_specialairlw3catch(); break;
                case "specialairlw3throw": anm_specialairlw3throw(); break;
                case "speciallw1landing": anm_speciallw1landing(); break;
                case "speciallw1loop": anm_speciallw1loop(); break;
                case "speciallw2kicklanding": anm_speciallw2kicklanding(); break;
                case "speciallw2landing": anm_speciallw2landing(); break;
                case "speciallw2start": anm_speciallw2start(); break;
                case "speciallw3": anm_speciallw3(); break;
                case "speciallw3catch": anm_speciallw3catch(); break;
                case "speciallw3throw": anm_speciallw3throw(); break;
                case "specialairs3captured": anm_specialairs3captured(); break;
                case "specialairs3capturedbig": anm_specialairs3capturedbig(); break;
                case "specialairs3captureddx": anm_specialairs3captureddx(); break;
                case "specialairs3capturedgirl": anm_specialairs3capturedgirl(); break;
                case "specialairs3fallbig": anm_specialairs3fallbig(); break;
                case "specialairs3falldx": anm_specialairs3falldx(); break;
                case "specialairs3fallgirl": anm_specialairs3fallgirl(); break;
                case "specialairs3landingbig": anm_specialairs3landingbig(); break;
                case "specialairs3landingdx": anm_specialairs3landingdx(); break;
                case "specialairs3landinggirl": anm_specialairs3landinggirl(); break;
                case "specials3thrown": anm_specials3thrown(); break;
                case "specials3thrownbig": anm_specials3thrownbig(); break;
                case "specials3throwndx": anm_specials3throwndx(); break;
                case "specials3throwngirl": anm_specials3throwngirl(); break;
                case "speciallw3thrown": anm_speciallw3thrown(); break;
                case "speciallw3thrownbig": anm_speciallw3thrownbig(); break;
                case "speciallw3throwndx": anm_speciallw3throwndx(); break;
                case "speciallw3throwngirl": anm_speciallw3throwngirl(); break;
                case "menupose": anm_menupose(); break;
                case "menupose2": anm_menupose2(); break;
                case "specialairn1cancel": anm_specialairn1cancel(); break;
                case "specialairn1hold": anm_specialairn1hold(); break;
                case "specialairn1jumpcancel": anm_specialairn1jumpcancel(); break;
                case "specialairn1start": anm_specialairn1start(); break;
                case "specialairn2end": anm_specialairn2end(); break;
                case "specialairn2loop": anm_specialairn2loop(); break;
                case "specialairn3end": anm_specialairn3end(); break;
                case "specialairn3start": anm_specialairn3start(); break;
                case "specialn1cancel": anm_specialn1cancel(); break;
                case "specialn1hold": anm_specialn1hold(); break;
                case "specialn1start": anm_specialn1start(); break;
                case "specialn2end": anm_specialn2end(); break;
                case "specialn2loop": anm_specialn2loop(); break;
                case "specialn3end": anm_specialn3end(); break;
                case "specialn3start": anm_specialn3start(); break;
                case "specialairs2loop": anm_specialairs2loop(); break;
                case "specialairs31": anm_specialairs31(); break;
                case "specials2loop": anm_specials2loop(); break;
                case "specials31": anm_specials31(); break;
                case "specialairhi2squat": anm_specialairhi2squat(); break;
                case "specialairhi3end": anm_specialairhi3end(); break;
                case "specialairhi3start": anm_specialairhi3start(); break;
                case "specialhi2squat": anm_specialhi2squat(); break;
                case "specialhi3b": anm_specialhi3b(); break;
                case "specialhi3f": anm_specialhi3f(); break;
                case "specialhi3start": anm_specialhi3start(); break;
                case "specialairlw1end": anm_specialairlw1end(); break;
                case "specialairlw1endl": anm_specialairlw1endl(); break;
                case "specialairlw1hit": anm_specialairlw1hit(); break;
                case "specialairlw1hitl": anm_specialairlw1hitl(); break;
                case "specialairlw1loop": anm_specialairlw1loop(); break;
                case "specialairlw1loopl": anm_specialairlw1loopl(); break;
                case "specialairlw1start": anm_specialairlw1start(); break;
                case "specialairlw1startl": anm_specialairlw1startl(); break;
                case "specialairlw3end": anm_specialairlw3end(); break;
                case "specialairlw3hit": anm_specialairlw3hit(); break;
                case "specialairlw3hold": anm_specialairlw3hold(); break;
                case "specialairlw3start": anm_specialairlw3start(); break;
                case "speciallw1end": anm_speciallw1end(); break;
                case "speciallw1endl": anm_speciallw1endl(); break;
                case "speciallw1hit": anm_speciallw1hit(); break;
                case "speciallw1hitl": anm_speciallw1hitl(); break;
                case "speciallw1loopl": anm_speciallw1loopl(); break;
                case "speciallw1start": anm_speciallw1start(); break;
                case "speciallw1startl": anm_speciallw1startl(); break;
                case "speciallw3end": anm_speciallw3end(); break;
                case "speciallw3hit": anm_speciallw3hit(); break;
                case "speciallw3hold": anm_speciallw3hold(); break;
                case "speciallw3start": anm_speciallw3start(); break;
                case "finalaird": anm_finalaird(); break;
                case "finalairu": anm_finalairu(); break;
                case "finald": anm_finald(); break;
                case "finalu": anm_finalu(); break;
                case "specialairn3endturn": anm_specialairn3endturn(); break;
                case "specialairn3loop": anm_specialairn3loop(); break;
                case "specialn3endturn": anm_specialn3endturn(); break;
                case "specialn3loop": anm_specialn3loop(); break;
                case "specialairs1end": anm_specialairs1end(); break;
                case "specialairs2attack": anm_specialairs2attack(); break;
                case "specialairs2dash": anm_specialairs2dash(); break;
                case "specialairs2hold": anm_specialairs2hold(); break;
                case "specialairs31hi": anm_specialairs31hi(); break;
                case "specialairs31lw": anm_specialairs31lw(); break;
                case "specials1end": anm_specials1end(); break;
                case "specials1hit": anm_specials1hit(); break;
                case "specials2attack": anm_specials2attack(); break;
                case "specials2dash": anm_specials2dash(); break;
                case "specials2hold": anm_specials2hold(); break;
                case "specials31hi": anm_specials31hi(); break;
                case "specials31lw": anm_specials31lw(); break;
                case "specialairhi1loop": anm_specialairhi1loop(); break;
                case "specialairhi1start": anm_specialairhi1start(); break;
                case "specialhi1end": anm_specialhi1end(); break;
                case "specialhi1start": anm_specialhi1start(); break;
                case "specialhi2bound": anm_specialhi2bound(); break;
                case "specialhi2fall": anm_specialhi2fall(); break;
                case "specialhi2hold": anm_specialhi2hold(); break;
                case "specialhi2holdair": anm_specialhi2holdair(); break;
                case "specialhi2landing": anm_specialhi2landing(); break;
                case "specialhi3hold": anm_specialhi3hold(); break;
                case "specialairlw3endair": anm_specialairlw3endair(); break;
                case "speciallw3endair": anm_speciallw3endair(); break;
                case "attack11end": anm_attack11end(); break;
                case "attack12end": anm_attack12end(); break;
                case "specialairnfailure": anm_specialairnfailure(); break;
                case "specialairnhand": anm_specialairnhand(); break;
                case "specialairntake": anm_specialairntake(); break;
                case "specialairnuse": anm_specialairnuse(); break;
                case "specialairnuse2": anm_specialairnuse2(); break;
                case "specialnfailure": anm_specialnfailure(); break;
                case "specialnhand": anm_specialnhand(); break;
                case "specialntake": anm_specialntake(); break;
                case "specialnuse": anm_specialnuse(); break;
                case "specialnuse2": anm_specialnuse2(); break;
                case "specialairsride": anm_specialairsride(); break;
                case "specialairsrideloop": anm_specialairsrideloop(); break;
                case "specialsride": anm_specialsride(); break;
                case "specialsrideloop": anm_specialsrideloop(); break;
                case "specialairhidetach": anm_specialairhidetach(); break;
                case "specialairhiflap2": anm_specialairhiflap2(); break;
                case "specialairhilanding2": anm_specialairhilanding2(); break;
                case "specialairhiwait2": anm_specialairhiwait2(); break;
                case "specialairlw1failure": anm_specialairlw1failure(); break;
                case "speciallw1failure": anm_speciallw1failure(); break;
                case "speciallw2legsdashb": anm_speciallw2legsdashb(); break;
                case "speciallw2legsdashf": anm_speciallw2legsdashf(); break;
                case "finalaircheerr": anm_finalaircheerr(); break;
                case "finalairhappyr": anm_finalairhappyr(); break;
                case "finalairmoneyr": anm_finalairmoneyr(); break;
                case "finalairr": anm_finalairr(); break;
                case "finalairsurpriser": anm_finalairsurpriser(); break;
                case "finalcheerr": anm_finalcheerr(); break;
                case "finalhappyr": anm_finalhappyr(); break;
                case "finalmoneyr": anm_finalmoneyr(); break;
                case "finalr": anm_finalr(); break;
                case "finalsurpriser": anm_finalsurpriser(); break;
                case "itemhandhavel": anm_itemhandhavel(); break;
                case "turnl": anm_turnl(); break;
                case "turndashl": anm_turndashl(); break;
                case "turnrunbrakel": anm_turnrunbrakel(); break;
                case "turnrunl": anm_turnrunl(); break;
                case "escapefl": anm_escapefl(); break;
                case "specialairs2nana": anm_specialairs2nana(); break;
                case "specials2nana": anm_specials2nana(); break;
                case "specialairhistartnana": anm_specialairhistartnana(); break;
                case "specialairhithrow2": anm_specialairhithrow2(); break;
                case "specialhistartnana": anm_specialhistartnana(); break;
                case "specialhithrow2": anm_specialhithrow2(); break;
                case "specialhithrow2nana": anm_specialhithrow2nana(); break;
                case "specialhithrownana": anm_specialhithrownana(); break;
                case "final1r": anm_final1r(); break;
                case "final2nana": anm_final2nana(); break;
                case "finalair1r": anm_finalair1r(); break;
                case "finalair2nana": anm_finalair2nana(); break;
                case "finalhang": anm_finalhang(); break;
                case "finalhangnana": anm_finalhangnana(); break;
                case "throwbnana": anm_throwbnana(); break;
                case "throwfnana": anm_throwfnana(); break;
                case "throwhinana": anm_throwhinana(); break;
                case "throwlwnana": anm_throwlwnana(); break;
                case "capturepanicnana": anm_capturepanicnana(); break;
                case "entryrnana": anm_entryrnana(); break;
                case "losenana": anm_losenana(); break;
                case "win1nana": anm_win1nana(); break;
                case "win1waitnana": anm_win1waitnana(); break;
                case "win2nana": anm_win2nana(); break;
                case "win2waitnana": anm_win2waitnana(); break;
                case "win3nana": anm_win3nana(); break;
                case "win3waitnana": anm_win3waitnana(); break;
                case "capture2facial": anm_capture2facial(); break;
                case "capture3facial": anm_capture3facial(); break;
                case "capture4facial": anm_capture4facial(); break;
                case "capturefacial": anm_capturefacial(); break;
                case "specialnairfire": anm_specialnairfire(); break;
                case "defaulttemporarily": anm_defaulttemporarily(); break;
                case "squatsteppose": anm_squatsteppose(); break;
                case "squatstepposeback": anm_squatstepposeback(); break;
                case "attack100end": anm_attack100end(); break;
                case "attck100start": anm_attck100start(); break;
                case "specialairnshootb": anm_specialairnshootb(); break;
                case "specialairnshootf": anm_specialairnshootf(); break;
                case "specialairnwait": anm_specialairnwait(); break;
                case "specialnshootb": anm_specialnshootb(); break;
                case "specialnshootf": anm_specialnshootf(); break;
                case "specialairscancel": anm_specialairscancel(); break;
                case "specialairscharge": anm_specialairscharge(); break;
                case "specialairsjumpcancel": anm_specialairsjumpcancel(); break;
                case "specialairsshoot": anm_specialairsshoot(); break;
                case "specialscancel": anm_specialscancel(); break;
                case "specialscharge": anm_specialscharge(); break;
                case "specialsshoot": anm_specialsshoot(); break;
                case "specialairhiclownfall": anm_specialairhiclownfall(); break;
                case "specialhicliffcatch": anm_specialhicliffcatch(); break;
                case "specialhiclownfall": anm_specialhiclownfall(); break;
                case "specialairlwbite": anm_specialairlwbite(); break;
                case "specialairlwcharge": anm_specialairlwcharge(); break;
                case "specialairlwfallb": anm_specialairlwfallb(); break;
                case "specialairlwfallend": anm_specialairlwfallend(); break;
                case "specialairlwfallf": anm_specialairlwfallf(); break;
                case "speciallwbite": anm_speciallwbite(); break;
                case "speciallwcharge": anm_speciallwcharge(); break;
                case "speciallwfallb": anm_speciallwfallb(); break;
                case "speciallwfallend": anm_speciallwfallend(); break;
                case "speciallwfallf": anm_speciallwfallf(); break;
                case "specialairsloop": anm_specialairsloop(); break;
                case "specialairsreturn": anm_specialairsreturn(); break;
                case "specialschange": anm_specialschange(); break;
                case "specialsloop": anm_specialsloop(); break;
                case "specialsmove": anm_specialsmove(); break;
                case "specialsreturn": anm_specialsreturn(); break;
                case "specialairlwfailure": anm_specialairlwfailure(); break;
                case "speciallwfailure": anm_speciallwfailure(); break;
                case "capturedamagepacmanzitabata": anm_capturedamagepacmanzitabata(); break;
                case "capturepacmanzitabata": anm_capturepacmanzitabata(); break;
                case "capturepulledpacmanzitabata": anm_capturepulledpacmanzitabata(); break;
                case "gost": anm_gost(); break;
                case "ijike": anm_ijike(); break;
                case "specialairlwattackl": anm_specialairlwattackl(); break;
                case "specialairlwattackr": anm_specialairlwattackr(); break;
                case "specialairlwl": anm_specialairlwl(); break;
                case "specialairlwreflect": anm_specialairlwreflect(); break;
                case "speciallwattackl": anm_speciallwattackl(); break;
                case "speciallwattackr": anm_speciallwattackr(); break;
                case "speciallwl": anm_speciallwl(); break;
                case "speciallwreflect": anm_speciallwreflect(); break;
                case "finalairbeam": anm_finalairbeam(); break;
                case "finalairbeamendr": anm_finalairbeamendr(); break;
                case "finalairbeamstart": anm_finalairbeamstart(); break;
                case "finalbeam": anm_finalbeam(); break;
                case "finalbeamendr": anm_finalbeamendr(); break;
                case "finalbeamstart": anm_finalbeamstart(); break;
                case "specialairlwin": anm_specialairlwin(); break;
                case "specialairlwout": anm_specialairlwout(); break;
                case "speciallwin": anm_speciallwin(); break;
                case "speciallwout": anm_speciallwout(); break;
                case "catchattackm": anm_catchattackm(); break;
                case "catchwaitm": anm_catchwaitm(); break;
                case "snakethrownlw": anm_snakethrownlw(); break;
                case "respawn": anm_respawn(); break;
                case "specialairsmissend": anm_specialairsmissend(); break;
                case "specialairsready": anm_specialairsready(); break;
                case "specialsready": anm_specialsready(); break;
                case "specialairhilanding1": anm_specialairhilanding1(); break;
                case "specialairhiwait1": anm_specialairhiwait1(); break;
                case "specialairnfirehi": anm_specialairnfirehi(); break;
                case "specialairnfires": anm_specialairnfires(); break;
                case "specialairnhitos": anm_specialairnhitos(); break;
                case "specialairnholdhi": anm_specialairnholdhi(); break;
                case "specialairnholds": anm_specialairnholds(); break;
                case "specialairnstohi": anm_specialairnstohi(); break;
                case "specialairnstos": anm_specialairnstos(); break;
                case "specialnfirehi": anm_specialnfirehi(); break;
                case "specialnfires": anm_specialnfires(); break;
                case "specialnhitos": anm_specialnhitos(); break;
                case "specialnholdhi": anm_specialnholdhi(); break;
                case "specialnholds": anm_specialnholds(); break;
                case "specialnstohi": anm_specialnstohi(); break;
                case "specialnstos": anm_specialnstos(); break;
                case "specialairlwendr": anm_specialairlwendr(); break;
                case "specialairlwstartr": anm_specialairlwstartr(); break;
                case "speciallwendr": anm_speciallwendr(); break;
                case "speciallwstartr": anm_speciallwstartr(); break;
                case "finalride": anm_finalride(); break;
                case "specialairsblown": anm_specialairsblown(); break;
                case "specialsblown": anm_specialsblown(); break;
                case "specialairnendr": anm_specialairnendr(); break;
                case "specialairnstartr": anm_specialairnstartr(); break;
                case "specialnendr": anm_specialnendr(); break;
                case "specialnstartr": anm_specialnstartr(); break;
                case "specialairhir": anm_specialairhir(); break;
                case "specialhir": anm_specialhir(); break;
                case "specialairshit": anm_specialairshit(); break;
                case "specialsoverturn": anm_specialsoverturn(); break;
                case "specialsoverturnstart": anm_specialsoverturnstart(); break;
                case "win3g_us_en": anm_win3g_us_en(); break;
                case "attackhi42": anm_attackhi42(); break;
                case "specialairntronend": anm_specialairntronend(); break;
                case "specialairntronhold": anm_specialairntronhold(); break;
                case "specialairntronstart": anm_specialairntronstart(); break;
                case "specialntronend": anm_specialntronend(); break;
                case "specialntronhold": anm_specialntronhold(); break;
                case "specialntronstart": anm_specialntronstart(); break;
                case "specialairhifail": anm_specialairhifail(); break;
                case "specialairlwcapture": anm_specialairlwcapture(); break;
                case "speciallwcapture": anm_speciallwcapture(); break;
                case "nobookhand": anm_nobookhand(); break;
                case "resurrectionbook": anm_resurrectionbook(); break;
                case "resurrectionthundersword": anm_resurrectionthundersword(); break;
                case "book": anm_book(); break;
                case "thunderswordm": anm_thunderswordm(); break;
                case "attackairhold": anm_attackairhold(); break;
                case "attackairholdend": anm_attackairholdend(); break;
                case "attackairholdstart": anm_attackairholdstart(); break;
                case "attackairholdstarts3": anm_attackairholdstarts3(); break;
                case "attackhold": anm_attackhold(); break;
                case "attackholdend": anm_attackholdend(); break;
                case "attackholdstart": anm_attackholdstart(); break;
                case "attackholdstarts3": anm_attackholdstarts3(); break;
                case "attacklw32": anm_attacklw32(); break;
                case "attacklw32landing": anm_attacklw32landing(); break;
                case "attackairbhi": anm_attackairbhi(); break;
                case "attackairblw": anm_attackairblw(); break;
                case "attackairfhi": anm_attackairfhi(); break;
                case "attackairflw": anm_attackairflw(); break;
                case "attackairlw2": anm_attackairlw2(); break;
                case "landingairlw2": anm_landingairlw2(); break;
                case "specialairscut": anm_specialairscut(); break;
                case "specialairsdragjump": anm_specialairsdragjump(); break;
                case "specialsdrag": anm_specialsdrag(); break;
                case "specialsdragcliff": anm_specialsdragcliff(); break;
                case "specialsdragf": anm_specialsdragf(); break;
                case "specialsdragwall": anm_specialsdragwall(); break;
                case "specialairhiceil": anm_specialairhiceil(); break;
                case "specialairhichargeendb": anm_specialairhichargeendb(); break;
                case "specialairhichargeendf": anm_specialairhichargeendf(); break;
                case "specialairhichargeendhi": anm_specialairhichargeendhi(); break;
                case "specialairhichargeendlw": anm_specialairhichargeendlw(); break;
                case "specialairhichargehi": anm_specialairhichargehi(); break;
                case "specialairhichargelw": anm_specialairhichargelw(); break;
                case "specialairhichargestartb": anm_specialairhichargestartb(); break;
                case "specialairhichargestartf": anm_specialairhichargestartf(); break;
                case "specialairhichargestarthi": anm_specialairhichargestarthi(); break;
                case "specialairhichargestartlw": anm_specialairhichargestartlw(); break;
                case "specialairhihover": anm_specialairhihover(); break;
                case "specialairhiwallb": anm_specialairhiwallb(); break;
                case "specialairhiwallf": anm_specialairhiwallf(); break;
                case "specialhilandingf": anm_specialhilandingf(); break;
                case "specialhilandinglw": anm_specialhilandinglw(); break;
                case "specialairlwfinish": anm_specialairlwfinish(); break;
                case "specialairlwstab": anm_specialairlwstab(); break;
                case "speciallwfinish": anm_speciallwfinish(); break;
                case "speciallwstab": anm_speciallwstab(); break;
                case "speciallwstabbed": anm_speciallwstabbed(); break;
                case "speciallwstabbedbig": anm_speciallwstabbedbig(); break;
                case "speciallwstabbeddx": anm_speciallwstabbeddx(); break;
                case "speciallwstabbedgirl": anm_speciallwstabbedgirl(); break;
                case "speciallwstabbedsmall": anm_speciallwstabbedsmall(); break;
                case "finaldashloop": anm_finaldashloop(); break;
                case "specialscaught": anm_specialscaught(); break;
                case "specialscaughtbig": anm_specialscaughtbig(); break;
                case "specialscaughtdx": anm_specialscaughtdx(); break;
                case "specialscaughtgirl": anm_specialscaughtgirl(); break;
                case "specialsdragged": anm_specialsdragged(); break;
                case "specialsdraggedbig": anm_specialsdraggedbig(); break;
                case "specialsdraggedcliff": anm_specialsdraggedcliff(); break;
                case "specialsdraggedcliffbig": anm_specialsdraggedcliffbig(); break;
                case "specialsdraggedcliffdx": anm_specialsdraggedcliffdx(); break;
                case "specialsdraggedcliffgirl": anm_specialsdraggedcliffgirl(); break;
                case "specialsdraggeddx": anm_specialsdraggeddx(); break;
                case "specialsdraggedf": anm_specialsdraggedf(); break;
                case "specialsdraggedfbig": anm_specialsdraggedfbig(); break;
                case "specialsdraggedfdx": anm_specialsdraggedfdx(); break;
                case "specialsdraggedfgirl": anm_specialsdraggedfgirl(); break;
                case "specialsdraggedgirl": anm_specialsdraggedgirl(); break;
                case "specialsdraggedwall": anm_specialsdraggedwall(); break;
                case "specialsdraggedwallbig": anm_specialsdraggedwallbig(); break;
                case "specialsdraggedwalldx": anm_specialsdraggedwalldx(); break;
                case "specialsdraggedwallgirl": anm_specialsdraggedwallgirl(); break;
                case "specialhirise": anm_specialhirise(); break;
                case "empty": anm_empty(); break;
                case "indicator": anm_indicator(); break;
                case "attack1": anm_attack1(); break;
                case "attack1end": anm_attack1end(); break;
                case "attack1start": anm_attack1start(); break;
                case "attack1turn": anm_attack1turn(); break;
                case "attacks3end": anm_attacks3end(); break;
                case "attacks3fast": anm_attacks3fast(); break;
                case "attacks3middle": anm_attacks3middle(); break;
                case "attacks3slow": anm_attacks3slow(); break;
                case "attacks3start": anm_attacks3start(); break;
                case "attackairnend": anm_attackairnend(); break;
                case "attackairnstart": anm_attackairnstart(); break;
                case "specialairnturnempty": anm_specialairnturnempty(); break;
                case "specialnturnempty": anm_specialnturnempty(); break;
                case "specialhisquat": anm_specialhisquat(); break;
                case "capturedamagedxzitabata": anm_capturedamagedxzitabata(); break;
                case "capturedamagegirlzitabata": anm_capturedamagegirlzitabata(); break;
                case "capturedamagezitabata": anm_capturedamagezitabata(); break;
                case "capturedxzitabata": anm_capturedxzitabata(); break;
                case "capturegirlzitabata": anm_capturegirlzitabata(); break;
                case "capturepulleddxzitabata": anm_capturepulleddxzitabata(); break;
                case "capturepulledgirlzitabata": anm_capturepulledgirlzitabata(); break;
                case "capturepulledzitabata": anm_capturepulledzitabata(); break;
                case "capturezitabata": anm_capturezitabata(); break;
                case "specialairnchargestart": anm_specialairnchargestart(); break;
                case "specialairnreturn": anm_specialairnreturn(); break;
                case "specialnchargestart": anm_specialnchargestart(); break;
                case "specialnreturn": anm_specialnreturn(); break;
                case "finalairhitend": anm_finalairhitend(); break;
                case "finalhitfall": anm_finalhitfall(); break;
                case "finalhitlanding": anm_finalhitlanding(); break;
                case "finaldamage01": anm_finaldamage01(); break;
                case "finaldamage02": anm_finaldamage02(); break;
                case "finaldamage03": anm_finaldamage03(); break;
                case "special": anm_special(); break;
                case "specialair": anm_specialair(); break;
                case "eye": anm_eye(); break;
                case "specialairsfire": anm_specialairsfire(); break;
                case "specialsfire": anm_specialsfire(); break;
                case "speciallwattacklanding": anm_speciallwattacklanding(); break;
                case "speciallwreturn": anm_speciallwreturn(); break;
                case "speciallwreturnlanding": anm_speciallwreturnlanding(); break;
                case "specialairscatchwait": anm_specialairscatchwait(); break;
                case "specialairshitreel": anm_specialairshitreel(); break;
                case "specialairsitem": anm_specialairsitem(); break;
                case "specialairsreel": anm_specialairsreel(); break;
                case "specialairsreelhi": anm_specialairsreelhi(); break;
                case "specialairsreellw": anm_specialairsreellw(); break;
                case "specialairsthrowb": anm_specialairsthrowb(); break;
                case "specialairsthrowf": anm_specialairsthrowf(); break;
                case "specialairsthrowhi": anm_specialairsthrowhi(); break;
                case "specialairsthrowlw": anm_specialairsthrowlw(); break;
                case "specialscatchwait": anm_specialscatchwait(); break;
                case "specialscut": anm_specialscut(); break;
                case "specialshit": anm_specialshit(); break;
                case "specialshitreel": anm_specialshitreel(); break;
                case "specialsitem": anm_specialsitem(); break;
                case "specialsreel": anm_specialsreel(); break;
                case "specialsreelhi": anm_specialsreelhi(); break;
                case "specialsreellw": anm_specialsreellw(); break;
                case "specialsthrowb": anm_specialsthrowb(); break;
                case "specialsthrowf": anm_specialsthrowf(); break;
                case "specialsthrowhi": anm_specialsthrowhi(); break;
                case "specialsthrowlw": anm_specialsthrowlw(); break;
                case "specialairlwfire": anm_specialairlwfire(); break;
                case "speciallwfire": anm_speciallwfire(); break;
                case "speciallwset": anm_speciallwset(); break;
                case "specialsthrownb": anm_specialsthrownb(); break;
                case "specialsthrownbigb": anm_specialsthrownbigb(); break;
                case "specialsthrownbigf": anm_specialsthrownbigf(); break;
                case "specialsthrownbighi": anm_specialsthrownbighi(); break;
                case "specialsthrownbiglw": anm_specialsthrownbiglw(); break;
                case "specialsthrowndxb": anm_specialsthrowndxb(); break;
                case "specialsthrowndxf": anm_specialsthrowndxf(); break;
                case "specialsthrowndxhi": anm_specialsthrowndxhi(); break;
                case "specialsthrowndxlw": anm_specialsthrowndxlw(); break;
                case "specialsthrownf": anm_specialsthrownf(); break;
                case "specialsthrowngirlb": anm_specialsthrowngirlb(); break;
                case "specialsthrowngirlf": anm_specialsthrowngirlf(); break;
                case "specialsthrowngirlhi": anm_specialsthrowngirlhi(); break;
                case "specialsthrowngirllw": anm_specialsthrowngirllw(); break;
                case "specialsthrownhi": anm_specialsthrownhi(); break;
                case "specialsthrownlw": anm_specialsthrownlw(); break;
                case "specialairnbuster": anm_specialairnbuster(); break;
                case "specialairnjump": anm_specialairnjump(); break;
                case "specialairnshield": anm_specialairnshield(); break;
                case "specialairnsmash": anm_specialairnsmash(); break;
                case "specialairnspeed": anm_specialairnspeed(); break;
                case "specialnbuster": anm_specialnbuster(); break;
                case "specialnshield": anm_specialnshield(); break;
                case "specialnsmash": anm_specialnsmash(); break;
                case "specialnspeed": anm_specialnspeed(); break;
                case "specialhiadd": anm_specialhiadd(); break;
                case "specialairlwn": anm_specialairlwn(); break;
                case "finalvisualsceneattack": anm_finalvisualsceneattack(); break;
                case "finalvisualsceneentry": anm_finalvisualsceneentry(); break;
                case "specialairnthrowhi": anm_specialairnthrowhi(); break;
                case "specialairnthrowlw": anm_specialairnthrowlw(); break;
                case "specialairnthrowm": anm_specialairnthrowm(); break;
                case "specialnclose": anm_specialnclose(); break;
                case "specialnlegsdashb": anm_specialnlegsdashb(); break;
                case "specialnlegsdashf": anm_specialnlegsdashf(); break;
                case "specialnthrowhi": anm_specialnthrowhi(); break;
                case "specialnthrowlw": anm_specialnthrowlw(); break;
                case "specialnthrowm": anm_specialnthrowm(); break;
                case "specialairsaway": anm_specialairsaway(); break;
                case "specialairsoperation": anm_specialairsoperation(); break;
                case "specialsaway": anm_specialsaway(); break;
                case "specialsoperation": anm_specialsoperation(); break;
                case "specialairhihang": anm_specialairhihang(); break;
                case "specialairlwenemy": anm_specialairlwenemy(); break;
                case "specialairlwground": anm_specialairlwground(); break;
                case "specialairlwwall": anm_specialairlwwall(); break;
                case "speciallwenemy": anm_speciallwenemy(); break;
                case "speciallwground": anm_speciallwground(); break;
                case "speciallwsquatblast": anm_speciallwsquatblast(); break;
                case "speciallwsquatground": anm_speciallwsquatground(); break;
                case "speciallwsquatstart": anm_speciallwsquatstart(); break;
                case "speciallwwall": anm_speciallwwall(); break;
                case "finalairwait": anm_finalairwait(); break;
                case "finalairwaitl": anm_finalairwaitl(); break;
                case "finalappeal": anm_finalappeal(); break;
                case "finalappeall": anm_finalappeall(); break;
                case "finalwait": anm_finalwait(); break;
                case "finalwaitl": anm_finalwaitl(); break;
                case "capturedamagebigsnake": anm_capturedamagebigsnake(); break;
                case "capturedamagedxsnake": anm_capturedamagedxsnake(); break;
                case "capturedamagesnake": anm_capturedamagesnake(); break;
                case "capturepulledbigsnake": anm_capturepulledbigsnake(); break;
                case "capturepulleddxsnake": anm_capturepulleddxsnake(); break;
                case "capturepulledsnake": anm_capturepulledsnake(); break;
                case "capturewaitbigsnake": anm_capturewaitbigsnake(); break;
                case "capturewaitdxsnake": anm_capturewaitdxsnake(); break;
                case "capturewaitsnake": anm_capturewaitsnake(); break;
                case "appealend": anm_appealend(); break;
                case "appealwait": anm_appealwait(); break;
                case "appealsend": anm_appealsend(); break;
                case "appealsreceive": anm_appealsreceive(); break;
                case "appealsstart": anm_appealsstart(); break;
                case "appealstransmit": anm_appealstransmit(); break;
                case "specialnrebound": anm_specialnrebound(); break;
                case "specialairsendloop": anm_specialairsendloop(); break;
                case "specialairsendstart": anm_specialairsendstart(); break;
                case "specialsdashhi": anm_specialsdashhi(); break;
                case "specialsdashlw": anm_specialsdashlw(); break;
                case "specialsendloop": anm_specialsendloop(); break;
                case "specialsendstart": anm_specialsendstart(); break;
                case "specialairnshooth": anm_specialairnshooth(); break;
                case "specialnshooth": anm_specialnshooth(); break;
                case "specialairlwflip": anm_specialairlwflip(); break;
                case "specialairlwkick": anm_specialairlwkick(); break;
                case "specialairlwstep": anm_specialairlwstep(); break;
                case "speciallwkicklanding": anm_speciallwkicklanding(); break;
                case "dragonend": anm_dragonend(); break;
                case "dragonloop": anm_dragonloop(); break;
                case "dragonstart": anm_dragonstart(); break;
                case "dragonwait": anm_dragonwait(); break;
                case "attackbothend": anm_attackbothend(); break;
                case "attackbothendb": anm_attackbothendb(); break;
                case "attackbothendl": anm_attackbothendl(); break;
                case "attackbothendr": anm_attackbothendr(); break;
                case "attacklegsbothend": anm_attacklegsbothend(); break;
                case "attacklegsbothendb": anm_attacklegsbothendb(); break;
                case "attacklegsbothendl": anm_attacklegsbothendl(); break;
                case "attacklegsbothendr": anm_attacklegsbothendr(); break;
                case "attacklegsfall": anm_attacklegsfall(); break;
                case "attacklegsfallaerial": anm_attacklegsfallaerial(); break;
                case "attacklegsjumpaerialb": anm_attacklegsjumpaerialb(); break;
                case "attacklegsjumpaerialf": anm_attacklegsjumpaerialf(); break;
                case "attacklegsjumpb": anm_attacklegsjumpb(); break;
                case "attacklegsjumpf": anm_attacklegsjumpf(); break;
                case "attacklegsjumpsquat": anm_attacklegsjumpsquat(); break;
                case "attacklegslandingheavy": anm_attacklegslandingheavy(); break;
                case "attacklegslandinglight": anm_attacklegslandinglight(); break;
                case "attacklegslongendl1": anm_attacklegslongendl1(); break;
                case "attacklegslongendlb1": anm_attacklegslongendlb1(); break;
                case "attacklegslongendlb3": anm_attacklegslongendlb3(); break;
                case "attacklegslongendr1": anm_attacklegslongendr1(); break;
                case "attacklegslongendrb1": anm_attacklegslongendrb1(); break;
                case "attacklegslongendrb3": anm_attacklegslongendrb3(); break;
                case "attacklegslongl1": anm_attacklegslongl1(); break;
                case "attacklegslongl2": anm_attacklegslongl2(); break;
                case "attacklegslongl3": anm_attacklegslongl3(); break;
                case "attacklegslonglb1": anm_attacklegslonglb1(); break;
                case "attacklegslonglb2": anm_attacklegslonglb2(); break;
                case "attacklegslonglb3": anm_attacklegslonglb3(); break;
                case "attacklegslongpulll2": anm_attacklegslongpulll2(); break;
                case "attacklegslongpulll3": anm_attacklegslongpulll3(); break;
                case "attacklegslongpulllb2": anm_attacklegslongpulllb2(); break;
                case "attacklegslongpulllb3": anm_attacklegslongpulllb3(); break;
                case "attacklegslongpullr2": anm_attacklegslongpullr2(); break;
                case "attacklegslongpullr3": anm_attacklegslongpullr3(); break;
                case "attacklegslongpullrb2": anm_attacklegslongpullrb2(); break;
                case "attacklegslongpullrb3": anm_attacklegslongpullrb3(); break;
                case "attacklegslongr1": anm_attacklegslongr1(); break;
                case "attacklegslongr2": anm_attacklegslongr2(); break;
                case "attacklegslongr3": anm_attacklegslongr3(); break;
                case "attacklegslongrb1": anm_attacklegslongrb1(); break;
                case "attacklegslongrb2": anm_attacklegslongrb2(); break;
                case "attacklegslongrb3": anm_attacklegslongrb3(); break;
                case "attacklegslongstartl1": anm_attacklegslongstartl1(); break;
                case "attacklegslongstartl2": anm_attacklegslongstartl2(); break;
                case "attacklegslongstartl3": anm_attacklegslongstartl3(); break;
                case "attacklegslongstartlb1": anm_attacklegslongstartlb1(); break;
                case "attacklegslongstartlb2": anm_attacklegslongstartlb2(); break;
                case "attacklegslongstartlb3": anm_attacklegslongstartlb3(); break;
                case "attacklegslongstartr1": anm_attacklegslongstartr1(); break;
                case "attacklegslongstartr2": anm_attacklegslongstartr2(); break;
                case "attacklegslongstartr3": anm_attacklegslongstartr3(); break;
                case "attacklegslongstartrb1": anm_attacklegslongstartrb1(); break;
                case "attacklegslongstartrb2": anm_attacklegslongstartrb2(); break;
                case "attacklegslongstartrb3": anm_attacklegslongstartrb3(); break;
                case "attacklegss4chargel": anm_attacklegss4chargel(); break;
                case "attacklegss4chargelb": anm_attacklegss4chargelb(); break;
                case "attacklegss4charger": anm_attacklegss4charger(); break;
                case "attacklegss4chargerb": anm_attacklegss4chargerb(); break;
                case "attacklegsshortendl1": anm_attacklegsshortendl1(); break;
                case "attacklegsshortendlb1": anm_attacklegsshortendlb1(); break;
                case "attacklegsshortendlb3": anm_attacklegsshortendlb3(); break;
                case "attacklegsshortendr1": anm_attacklegsshortendr1(); break;
                case "attacklegsshortendrb1": anm_attacklegsshortendrb1(); break;
                case "attacklegsshortendrb3": anm_attacklegsshortendrb3(); break;
                case "attacklegsshortl1": anm_attacklegsshortl1(); break;
                case "attacklegsshortl2": anm_attacklegsshortl2(); break;
                case "attacklegsshortl3": anm_attacklegsshortl3(); break;
                case "attacklegsshortlb1": anm_attacklegsshortlb1(); break;
                case "attacklegsshortlb2": anm_attacklegsshortlb2(); break;
                case "attacklegsshortlb3": anm_attacklegsshortlb3(); break;
                case "attacklegsshortpulll2": anm_attacklegsshortpulll2(); break;
                case "attacklegsshortpulll3": anm_attacklegsshortpulll3(); break;
                case "attacklegsshortpulllb2": anm_attacklegsshortpulllb2(); break;
                case "attacklegsshortpulllb3": anm_attacklegsshortpulllb3(); break;
                case "attacklegsshortpullr2": anm_attacklegsshortpullr2(); break;
                case "attacklegsshortpullr3": anm_attacklegsshortpullr3(); break;
                case "attacklegsshortpullrb2": anm_attacklegsshortpullrb2(); break;
                case "attacklegsshortpullrb3": anm_attacklegsshortpullrb3(); break;
                case "attacklegsshortr1": anm_attacklegsshortr1(); break;
                case "attacklegsshortr2": anm_attacklegsshortr2(); break;
                case "attacklegsshortr3": anm_attacklegsshortr3(); break;
                case "attacklegsshortrb1": anm_attacklegsshortrb1(); break;
                case "attacklegsshortrb2": anm_attacklegsshortrb2(); break;
                case "attacklegsshortrb3": anm_attacklegsshortrb3(); break;
                case "attacklegsshortstartl1": anm_attacklegsshortstartl1(); break;
                case "attacklegsshortstartl2": anm_attacklegsshortstartl2(); break;
                case "attacklegsshortstartl3": anm_attacklegsshortstartl3(); break;
                case "attacklegsshortstartlb1": anm_attacklegsshortstartlb1(); break;
                case "attacklegsshortstartlb2": anm_attacklegsshortstartlb2(); break;
                case "attacklegsshortstartlb3": anm_attacklegsshortstartlb3(); break;
                case "attacklegsshortstartr1": anm_attacklegsshortstartr1(); break;
                case "attacklegsshortstartr2": anm_attacklegsshortstartr2(); break;
                case "attacklegsshortstartr3": anm_attacklegsshortstartr3(); break;
                case "attacklegsshortstartrb1": anm_attacklegsshortstartrb1(); break;
                case "attacklegsshortstartrb2": anm_attacklegsshortstartrb2(); break;
                case "attacklegsshortstartrb3": anm_attacklegsshortstartrb3(); break;
                case "attacklegssquat": anm_attacklegssquat(); break;
                case "attacklegssquatrv": anm_attacklegssquatrv(); break;
                case "attacklegssquatwait": anm_attacklegssquatwait(); break;
                case "attacklegstwfall": anm_attacklegstwfall(); break;
                case "attacklegstwfallaerial": anm_attacklegstwfallaerial(); break;
                case "attacklegstwjumpaerialb": anm_attacklegstwjumpaerialb(); break;
                case "attacklegstwjumpaerialf": anm_attacklegstwjumpaerialf(); break;
                case "attacklegstwjumpb": anm_attacklegstwjumpb(); break;
                case "attacklegstwjumpf": anm_attacklegstwjumpf(); break;
                case "attacklegstwjumpsquat": anm_attacklegstwjumpsquat(); break;
                case "attacklegstwlandingheavy": anm_attacklegstwlandingheavy(); break;
                case "attacklegstwlandinglight": anm_attacklegstwlandinglight(); break;
                case "attacklegstwsquat": anm_attacklegstwsquat(); break;
                case "attacklegstwsquatrv": anm_attacklegstwsquatrv(); break;
                case "attacklegstwsquatwait": anm_attacklegstwsquatwait(); break;
                case "attacklegstwwait": anm_attacklegstwwait(); break;
                case "attacklegstwwalkbrakel": anm_attacklegstwwalkbrakel(); break;
                case "attacklegstwwalkbrakelb": anm_attacklegstwwalkbrakelb(); break;
                case "attacklegstwwalkbraker": anm_attacklegstwwalkbraker(); break;
                case "attacklegstwwalkbrakerb": anm_attacklegstwwalkbrakerb(); break;
                case "attacklegstwwalkfast": anm_attacklegstwwalkfast(); break;
                case "attacklegstwwalkfastb": anm_attacklegstwwalkfastb(); break;
                case "attacklegstwwalkmiddle": anm_attacklegstwwalkmiddle(); break;
                case "attacklegstwwalkmiddleb": anm_attacklegstwwalkmiddleb(); break;
                case "attacklegstwwalkslow": anm_attacklegstwwalkslow(); break;
                case "attacklegstwwalkslowb": anm_attacklegstwwalkslowb(); break;
                case "attacklegswait": anm_attacklegswait(); break;
                case "attacklegswalkbrakel": anm_attacklegswalkbrakel(); break;
                case "attacklegswalkbrakelb": anm_attacklegswalkbrakelb(); break;
                case "attacklegswalkbraker": anm_attacklegswalkbraker(); break;
                case "attacklegswalkbrakerb": anm_attacklegswalkbrakerb(); break;
                case "attacklegswalkfast": anm_attacklegswalkfast(); break;
                case "attacklegswalkfastb": anm_attacklegswalkfastb(); break;
                case "attacklegswalkmiddle": anm_attacklegswalkmiddle(); break;
                case "attacklegswalkmiddleb": anm_attacklegswalkmiddleb(); break;
                case "attacklegswalkslow": anm_attacklegswalkslow(); break;
                case "attacklegswalkslowb": anm_attacklegswalkslowb(); break;
                case "attacklongendl1": anm_attacklongendl1(); break;
                case "attacklongendlb1": anm_attacklongendlb1(); break;
                case "attacklongendlb3": anm_attacklongendlb3(); break;
                case "attacklongendr1": anm_attacklongendr1(); break;
                case "attacklongendrb1": anm_attacklongendrb1(); break;
                case "attacklongendrb3": anm_attacklongendrb3(); break;
                case "attacklongl1": anm_attacklongl1(); break;
                case "attacklongl2": anm_attacklongl2(); break;
                case "attacklongl3": anm_attacklongl3(); break;
                case "attacklonglb1": anm_attacklonglb1(); break;
                case "attacklonglb2": anm_attacklonglb2(); break;
                case "attacklonglb3": anm_attacklonglb3(); break;
                case "attacklongpulll2": anm_attacklongpulll2(); break;
                case "attacklongpulll3": anm_attacklongpulll3(); break;
                case "attacklongpulllb2": anm_attacklongpulllb2(); break;
                case "attacklongpulllb3": anm_attacklongpulllb3(); break;
                case "attacklongpullr2": anm_attacklongpullr2(); break;
                case "attacklongpullr3": anm_attacklongpullr3(); break;
                case "attacklongpullrb2": anm_attacklongpullrb2(); break;
                case "attacklongpullrb3": anm_attacklongpullrb3(); break;
                case "attacklongr1": anm_attacklongr1(); break;
                case "attacklongr2": anm_attacklongr2(); break;
                case "attacklongr3": anm_attacklongr3(); break;
                case "attacklongrb1": anm_attacklongrb1(); break;
                case "attacklongrb2": anm_attacklongrb2(); break;
                case "attacklongrb3": anm_attacklongrb3(); break;
                case "attacklongstartl1": anm_attacklongstartl1(); break;
                case "attacklongstartl2": anm_attacklongstartl2(); break;
                case "attacklongstartl3": anm_attacklongstartl3(); break;
                case "attacklongstartlb1": anm_attacklongstartlb1(); break;
                case "attacklongstartlb2": anm_attacklongstartlb2(); break;
                case "attacklongstartlb3": anm_attacklongstartlb3(); break;
                case "attacklongstartr1": anm_attacklongstartr1(); break;
                case "attacklongstartr2": anm_attacklongstartr2(); break;
                case "attacklongstartr3": anm_attacklongstartr3(); break;
                case "attacklongstartrb1": anm_attacklongstartrb1(); break;
                case "attacklongstartrb2": anm_attacklongstartrb2(); break;
                case "attacklongstartrb3": anm_attacklongstartrb3(); break;
                case "attacks4chargel": anm_attacks4chargel(); break;
                case "attacks4chargelb": anm_attacks4chargelb(); break;
                case "attacks4charger": anm_attacks4charger(); break;
                case "attacks4chargerb": anm_attacks4chargerb(); break;
                case "attackshortendl1": anm_attackshortendl1(); break;
                case "attackshortendlb1": anm_attackshortendlb1(); break;
                case "attackshortendlb3": anm_attackshortendlb3(); break;
                case "attackshortendr1": anm_attackshortendr1(); break;
                case "attackshortendrb1": anm_attackshortendrb1(); break;
                case "attackshortendrb3": anm_attackshortendrb3(); break;
                case "attackshortl1": anm_attackshortl1(); break;
                case "attackshortl2": anm_attackshortl2(); break;
                case "attackshortl3": anm_attackshortl3(); break;
                case "attackshortlb1": anm_attackshortlb1(); break;
                case "attackshortlb2": anm_attackshortlb2(); break;
                case "attackshortlb3": anm_attackshortlb3(); break;
                case "attackshortpulll2": anm_attackshortpulll2(); break;
                case "attackshortpulll3": anm_attackshortpulll3(); break;
                case "attackshortpulllb2": anm_attackshortpulllb2(); break;
                case "attackshortpulllb3": anm_attackshortpulllb3(); break;
                case "attackshortpullr2": anm_attackshortpullr2(); break;
                case "attackshortpullr3": anm_attackshortpullr3(); break;
                case "attackshortpullrb2": anm_attackshortpullrb2(); break;
                case "attackshortpullrb3": anm_attackshortpullrb3(); break;
                case "attackshortr1": anm_attackshortr1(); break;
                case "attackshortr2": anm_attackshortr2(); break;
                case "attackshortr3": anm_attackshortr3(); break;
                case "attackshortrb1": anm_attackshortrb1(); break;
                case "attackshortrb2": anm_attackshortrb2(); break;
                case "attackshortrb3": anm_attackshortrb3(); break;
                case "attackshortstartl1": anm_attackshortstartl1(); break;
                case "attackshortstartl2": anm_attackshortstartl2(); break;
                case "attackshortstartl3": anm_attackshortstartl3(); break;
                case "attackshortstartlb1": anm_attackshortstartlb1(); break;
                case "attackshortstartlb2": anm_attackshortstartlb2(); break;
                case "attackshortstartlb3": anm_attackshortstartlb3(); break;
                case "attackshortstartr1": anm_attackshortstartr1(); break;
                case "attackshortstartr2": anm_attackshortstartr2(); break;
                case "attackshortstartr3": anm_attackshortstartr3(); break;
                case "attackshortstartrb1": anm_attackshortstartrb1(); break;
                case "attackshortstartrb2": anm_attackshortstartrb2(); break;
                case "attackshortstartrb3": anm_attackshortstartrb3(); break;
                case "specialairhiend2": anm_specialairhiend2(); break;
                case "specialairhistart2": anm_specialairhistart2(); break;
                case "specialhilong": anm_specialhilong(); break;
                case "specialhilongend": anm_specialhilongend(); break;
                case "specialhishort": anm_specialhishort(); break;
                case "specialhishortend": anm_specialhishortend(); break;
                case "catchairend": anm_catchairend(); break;
                case "catchairreturn": anm_catchairreturn(); break;
                case "catchattackbig": anm_catchattackbig(); break;
                case "catchdashend": anm_catchdashend(); break;
                case "catchdashreturn": anm_catchdashreturn(); break;
                case "catchdashstart": anm_catchdashstart(); break;
                case "catchend": anm_catchend(); break;
                case "catchpull2": anm_catchpull2(); break;
                case "catchpull2big": anm_catchpull2big(); break;
                case "catchreturn": anm_catchreturn(); break;
                case "catchstart": anm_catchstart(); break;
                case "catchturnend": anm_catchturnend(); break;
                case "catchturnreturn": anm_catchturnreturn(); break;
                case "catchturnstart": anm_catchturnstart(); break;
                case "catchwaitbig": anm_catchwaitbig(); break;
                case "specialairnbite": anm_specialairnbite(); break;
                case "specialairnbiteend": anm_specialairnbiteend(); break;
                case "specialairnbitestart": anm_specialairnbitestart(); break;
                case "specialairnopen": anm_specialairnopen(); break;
                case "specialairnopenwait": anm_specialairnopenwait(); break;
                case "specialnbite": anm_specialnbite(); break;
                case "specialnbiteend": anm_specialnbiteend(); break;
                case "specialnbitestart": anm_specialnbitestart(); break;
                case "specialnopen": anm_specialnopen(); break;
                case "specialnopenwait": anm_specialnopenwait(); break;
                case "specialairsbride": anm_specialairsbride(); break;
                case "specialairsbump": anm_specialairsbump(); break;
                case "specialairsdown": anm_specialairsdown(); break;
                case "specialairssearch": anm_specialairssearch(); break;
                case "specialsappeal": anm_specialsappeal(); break;
                case "specialsbdrive": anm_specialsbdrive(); break;
                case "specialsblanding": anm_specialsblanding(); break;
                case "specialsbride": anm_specialsbride(); break;
                case "specialsbump": anm_specialsbump(); break;
                case "specialsdown": anm_specialsdown(); break;
                case "specialsescape": anm_specialsescape(); break;
                case "specialsescapestart": anm_specialsescapestart(); break;
                case "specialssearch": anm_specialssearch(); break;
                case "specialsturnend": anm_specialsturnend(); break;
                case "specialsturnloop": anm_specialsturnloop(); break;
                case "specialsturnstart": anm_specialsturnstart(); break;
                case "specialswheelie": anm_specialswheelie(); break;
                case "specialswheelieend": anm_specialswheelieend(); break;
                case "specialswheeliestart": anm_specialswheeliestart(); break;
                case "specialairlwflyr": anm_specialairlwflyr(); break;
                case "specialairlwlr": anm_specialairlwlr(); break;
                case "specialairlwmr": anm_specialairlwmr(); break;
                case "specialairlwsr": anm_specialairlwsr(); break;
                case "speciallwflyr": anm_speciallwflyr(); break;
                case "speciallwlandingflyr": anm_speciallwlandingflyr(); break;
                case "speciallwlandinglr": anm_speciallwlandinglr(); break;
                case "speciallwlr": anm_speciallwlr(); break;
                case "speciallwmr": anm_speciallwmr(); break;
                case "speciallwsr": anm_speciallwsr(); break;
                case "stomach": anm_stomach(); break;
                case "attackhi4chargel": anm_attackhi4chargel(); break;
                case "attackhi4l": anm_attackhi4l(); break;
                case "specialsheading": anm_specialsheading(); break;
                case "specialairlwfailurel": anm_specialairlwfailurel(); break;
                case "specialairlwfailurer": anm_specialairlwfailurer(); break;
                case "specialairlwsuccessl": anm_specialairlwsuccessl(); break;
                case "specialairlwsuccessr": anm_specialairlwsuccessr(); break;
                case "speciallwfailurel": anm_speciallwfailurel(); break;
                case "speciallwfailurer": anm_speciallwfailurer(); break;
                case "speciallwsuccessl": anm_speciallwsuccessl(); break;
                case "speciallwsuccessr": anm_speciallwsuccessr(); break;
                case "capturedamagedxzitabatahi": anm_capturedamagedxzitabatahi(); break;
                case "capturedamagedxzitabatalw": anm_capturedamagedxzitabatalw(); break;
                case "capturedamagegirlzitabatahi": anm_capturedamagegirlzitabatahi(); break;
                case "capturedamagegirlzitabatalw": anm_capturedamagegirlzitabatalw(); break;
                case "capturedamagezitabatahi": anm_capturedamagezitabatahi(); break;
                case "capturedamagezitabatalw": anm_capturedamagezitabatalw(); break;
                case "capturedxzitabatahi": anm_capturedxzitabatahi(); break;
                case "capturedxzitabatalw": anm_capturedxzitabatalw(); break;
                case "capturegirlzitabatahi": anm_capturegirlzitabatahi(); break;
                case "capturegirlzitabatalw": anm_capturegirlzitabatalw(); break;
                case "capturepulleddxzitabatahi": anm_capturepulleddxzitabatahi(); break;
                case "capturepulleddxzitabatalw": anm_capturepulleddxzitabatalw(); break;
                case "capturepulledgirlzitabatahi": anm_capturepulledgirlzitabatahi(); break;
                case "capturepulledgirlzitabatalw": anm_capturepulledgirlzitabatalw(); break;
                case "capturepulledzitabatahi": anm_capturepulledzitabatahi(); break;
                case "capturepulledzitabatalw": anm_capturepulledzitabatalw(); break;
                case "capturezitabatahi": anm_capturezitabatahi(); break;
                case "capturezitabatalw": anm_capturezitabatalw(); break;
                case "win1c_us_en": anm_win1c_us_en(); break;
                case "win1cwait_us_en": anm_win1cwait_us_en(); break;
                case "win1d_us_en": anm_win1d_us_en(); break;
                case "win1dwait_us_en": anm_win1dwait_us_en(); break;
                case "win1e_us_en": anm_win1e_us_en(); break;
                case "win1ewait_us_en": anm_win1ewait_us_en(); break;
                case "win1f_us_en": anm_win1f_us_en(); break;
                case "win1fwait_us_en": anm_win1fwait_us_en(); break;
                case "win2c_us_en": anm_win2c_us_en(); break;
                case "win2cwait_us_en": anm_win2cwait_us_en(); break;
                case "win2d_us_en": anm_win2d_us_en(); break;
                case "win2dwait_us_en": anm_win2dwait_us_en(); break;
                case "win2e_us_en": anm_win2e_us_en(); break;
                case "win2ewait_us_en": anm_win2ewait_us_en(); break;
                case "win3c_us_en": anm_win3c_us_en(); break;
                case "win3cwait_us_en": anm_win3cwait_us_en(); break;
                case "win3d_us_en": anm_win3d_us_en(); break;
                case "win3dwait_us_en": anm_win3dwait_us_en(); break;
                case "win3e_us_en": anm_win3e_us_en(); break;
                case "win3ewait_us_en": anm_win3ewait_us_en(); break;
                case "visualscene": anm_visualscene(); break;
                case "finalairfinish": anm_finalairfinish(); break;
                case "finalairloop": anm_finalairloop(); break;
                case "finalloop": anm_finalloop(); break;
            }
        }

        public virtual void anm_defaulteyelid()
        {

        }

        public virtual void anm_itemhandgrip()
        {

        }

        public virtual void anm_itemhandhave()
        {

        }

        public virtual void anm_itemhandpickup()
        {

        }

        public virtual void anm_itemhandsmash()
        {

        }

        public virtual void anm_wait1()
        {
            Wait();
        }

        public virtual void anm_wait3()
        {
            Wait();
        }

        public virtual void anm_wait4()
        {
            Wait();
        }

        public virtual void anm_wait5()
        {
            Wait();
        }

        public virtual void anm_waititem()
        {

        }

        public virtual void anm_turn()
        {
            DetectDash();

            WhenFinishedGoTo("wait1");
            TurnWhenDone();

            phy.MoveX(input.Cdir,10);
        }

        public virtual void anm_walkbrakel()
        {

        }

        public virtual void anm_walkbraker()
        {

        }

        public virtual void anm_walkfast()
        {
            Walk();
        }

        public virtual void anm_walkmiddle()
        {
            Walk();
        }

        public virtual void anm_walkslow()
        {
            Walk();
        }

        public virtual void anm_dash()
        {
            if (anim.CurrentKeyIndex >= Peram.DashMid && anim.CurrentKeyIndex < Peram.DashMid + 3 && input.Cdir != 0)
            {
                anim.CrossFade("run");
            }

            if (anim.CurrentKeyIndex > Peram.DashMid)
                phy.MoveX(0,5);

            if (input.Cdir.Tapped)
            {
                if (input.Cdir == Gdir)
                {
                    Dash("dash");
                }
            }

            if (input.Cdir == -Gdir)
            {
                Dash("turndash",true);
            }

            WhenFinishedGoTo("wait1");

            DetectMoveFall();

            DetectHitWall();

            DetectCatch("catchdash");
        }

        public virtual void anm_run()
        {
            if (input.Cdir == 0)
            {
                RunStopTimer += Window.MainWindow.GlobalDeltaTime;

                if (RunStopTimer >= 3)
                {
                    anim.CrossFade("runbrakel");
                }
            }
            else
            {
                if (input.Cdir == -Gdir)
                {
                    anim.CrossFade("turnrun");
                }
            }

            DetectMoveFall();

            MoveInAnimation();

            DetectHitWall();

            DetectCatch("catchdash");
        }

        public virtual void anm_runbrakel()
        {
            RunBreak();
        }

        public virtual void anm_runbraker()
        {
            RunBreak();
        }

        public virtual void anm_turndash()
        {
            if (input.Cdir == Gdir)
            {
                Dash("turndash");

                Gdir = -input.Cdir.Ldir;
            }
            else if (input.Cdir.Tapped)
            {
                Dash("dash",true);

                Gdir = input.Cdir.Ldir;
            }

            if (anim.CurrentKeyIndex >= Peram.DashMid && anim.CurrentKeyIndex <= Peram.DashMid + 3 && input.Cdir != 0)
            {
                anim.CrossFade("run");

                Gdir *= -1;
            }

            if (anim.CurrentKeyIndex > Peram.DashMid)
                phy.MoveX(0, 5);

            TurnWhenDone();

            WhenFinishedGoTo("wait1");

            DetectMoveFall();

            DetectHitWall();

            DetectCatch("catchdash",true);
        }

        public virtual void anm_turnrun()
        {
            if (input.Cdir == 0 && anim.CurrentKeyIndex < 15)
            {
                anim.CrossFade("turnrunbrake");
                Gdir *= -1;
            }

            if (input.Cdir == Gdir && anim.CurrentKeyIndex > 10)
            {
                anim.CrossFade("turn");

                Gdir *= -1;
            }

            phy.MoveX(0,Peram.TurnRunSpeed);

            WhenFinishedGoTo("run");

            TurnWhenDone();

            phy.HugLedge();

            DetectCatch("catchturn");
        }

        public virtual void anm_turnrunbrake()
        {
            WhenFinishedGoTo("wait1");

            if (input.Cdir == -Gdir)
                anim.CrossFade("turn");

            phy.MoveX(0,5);

            DetectCatch();

            phy.HugLedge();
        }

        public virtual void anm_jumpaerialb()
        {
            Jump();
        }

        public virtual void anm_jumpaerialf()
        {
            Jump();
        }

        public virtual void anm_jumpb()
        {
            Jump();
        }

        public virtual void anm_jumpf()
        {
            Jump();
        }

        public virtual void anm_jumpsquat()
        {
            if (anim.CurrentKeyIndex >= 3)
            {
                if (input.JumpButton.Down && !input.AttackController.Buffered)
                    phy.Velocity.Y = Peram.JumpHeight;
                else
                    phy.Velocity.Y = Peram.ShortJumpHeight;

                if (input.Cdir == 0 || input.Cdir == Gdir)
                {
                    anim.CrossFade("jumpf");
                }
                else
                {
                    anim.CrossFade("jumpb");
                }

                LandJumpParticals();
            }

            if (input.Cdir == 0)
                phy.Velocity.X = 0;

            phy.MoveX(0,5);
        }

        public virtual void anm_damagefall()
        {

        }

        public virtual void anm_fall()
        {
            Fall();
        }

        public virtual void anm_fallaerial()
        {
            Fall();
        }

        public virtual void anm_fallaerialb()
        {
            Fall();
        }

        public virtual void anm_fallaerialf()
        {
            Fall();
        }

        public virtual void anm_fallb()
        {
            Fall();
        }

        public virtual void anm_fallf()
        {
            Fall();
        }

        public virtual void anm_fallspecial()
        {

        }

        public virtual void anm_fallspecialb()
        {

        }

        public virtual void anm_fallspecialf()
        {

        }

        public virtual void anm_landingfallspecial()
        {

        }

        public virtual void anm_runfalll()
        {
            RunFall();
        }

        public virtual void anm_runfallr()
        {
            RunFall();
        }

        public virtual void anm_walkfalll()
        {
            RunFall();
        }

        public virtual void anm_walkfallr()
        {
            RunFall();
        }

        public virtual void anm_landingheavy()
        {
            Landing();
        }

        public virtual void anm_landinglight()
        {
            Landing();
        }

        public virtual void anm_squat()
        {
            WhenFinishedGoTo("squatwait");

            phy.MoveX(0, 10);
        }

        public virtual void anm_squatrv()
        {
            DetectSquat();

            WhenFinishedGoTo("wait1");

            phy.MoveX(0, 10);
        }

        public virtual void anm_squatwait()
        {
            if (input.Ydir.Value >= -0.5f)
            {
                anim.CrossFade("squatrv");
            }

            phy.MoveX(0,10);
        }

        public virtual void anm_squatwaititem()
        {

        }

        public virtual void anm_stepairpose()
        {

        }

        public virtual void anm_stepback()
        {

        }

        public virtual void anm_stepfall()
        {

        }

        public virtual void anm_stepjump()
        {

        }

        public virtual void anm_steppose()
        {

        }

        public virtual void anm_guard()
        {

        }

        public virtual void anm_guardoff()
        {

        }

        public virtual void anm_guardon()
        {

        }

        public virtual void anm_justshieldoff()
        {

        }

        public virtual void anm_guarddamage()
        {

        }

        public virtual void anm_escapeair()
        {

        }

        public virtual void anm_escapeb()
        {

        }

        public virtual void anm_escapef()
        {

        }

        public virtual void anm_escapen()
        {

        }

        public virtual void anm_rebound()
        {

        }

        public virtual void anm_attack100()
        {
            InAttack = true;

            if (anim.FinishedAnimation)
            {
                AttackA("attackend",true);
            }
        }

        public virtual void anm_attack100start()
        {
            if (anim.FinishedAnimation)
            {
                AttackA("attack100",true);
            }
        }

        public virtual void anm_attack11()
        {
            GroundAttack();
        }

        public virtual void anm_attack12()
        {
            GroundAttack();
        }

        public virtual void anm_attack13()
        {
            GroundAttack();
        }

        public virtual void anm_attackdash()
        {
            GroundAttack();
        }

        public virtual void anm_attackend()
        {
            GroundAttack();
        }

        public virtual void anm_attacks3()
        {

        }

        public virtual void anm_attacks32()
        {

        }

        public virtual void anm_attacks33()
        {

        }

        public virtual void anm_attackhi3()
        {
            GroundAttack();
        }

        public virtual void anm_attacklw3()
        {
            GroundAttack("squatwait");
        }

        public virtual void anm_attacks4charge()
        {

        }

        public virtual void anm_attacks4hi()
        {

        }

        public virtual void anm_attacks4lw()
        {

        }

        public virtual void anm_attacks4s()
        {
            GroundAttack();
        }

        public virtual void anm_attackhi4()
        {
            GroundAttack();
        }

        public virtual void anm_attackhi4charge()
        {

        }

        public virtual void anm_attacklw4()
        {
            GroundAttack();
        }

        public virtual void anm_attacklw4charge()
        {

        }

        public virtual void anm_attackairb()
        {
            AttackAir();
        }

        public virtual void anm_attackairf()
        {
            AttackAir();
        }

        public virtual void anm_attackairf2()
        {

        }

        public virtual void anm_attackairf3()
        {

        }

        public virtual void anm_attackairhi()
        {
            AttackAir();
        }

        public virtual void anm_attackairhihold()
        {

        }

        public virtual void anm_attackairlw()
        {
            AttackAir();
        }

        public virtual void anm_attackairn()
        {
            AttackAir();
        }

        public virtual void anm_attackairnhold()
        {

        }

        public virtual void anm_landingairb()
        {
            Landing();
        }

        public virtual void anm_landingairf()
        {
            Landing();
        }

        public virtual void anm_landingairf2()
        {

        }

        public virtual void anm_landingairf3()
        {

        }

        public virtual void anm_landingairhi()
        {
            Landing();
        }

        public virtual void anm_landingairlw()
        {
            Landing();
        }

        public virtual void anm_landingairn()
        {
            Landing();
        }

        public virtual void anm_specialairnchargef()
        {

        }

        public virtual void anm_specialairnchargeh()
        {

        }

        public virtual void anm_specialairnendf()
        {

        }

        public virtual void anm_specialairnendh()
        {

        }

        public virtual void anm_specialairnloopf()
        {

        }

        public virtual void anm_specialairnlooph()
        {

        }

        public virtual void anm_specialairnstartf()
        {

        }

        public virtual void anm_specialairnstarth()
        {

        }

        public virtual void anm_specialnchargef()
        {

        }

        public virtual void anm_specialnchargeh()
        {

        }

        public virtual void anm_specialnendf()
        {

        }

        public virtual void anm_specialnendh()
        {

        }

        public virtual void anm_specialnloopf()
        {

        }

        public virtual void anm_specialnlooph()
        {

        }

        public virtual void anm_specialnstartf()
        {

        }

        public virtual void anm_specialnstarth()
        {

        }

        public virtual void anm_specialairsd()
        {

        }

        public virtual void anm_specialairsdhit()
        {

        }

        public virtual void anm_specialairsdlanding()
        {

        }

        public virtual void anm_specialairsu()
        {

        }

        public virtual void anm_specials()
        {

        }

        public virtual void anm_specialsholdend()
        {

        }

        public virtual void anm_specialairhi()
        {

        }

        public virtual void anm_specialhi()
        {
            MoveInAnimation();

            WhenFinishedGoTo("fall");
        }

        public virtual void anm_specialairlw()
        {

        }

        public virtual void anm_speciallw()
        {

        }

        public virtual void anm_final()
        {

        }

        public virtual void anm_finalair()
        {

        }

        public virtual void anm_finalairendl()
        {

        }

        public virtual void anm_finalairendr()
        {

        }

        public virtual void anm_finalendl()
        {

        }

        public virtual void anm_finalendr()
        {

        }

        public virtual void anm_finalvisualscene01()
        {

        }

        public virtual void anm_catch()
        {
            Catch();
        }

        public virtual void anm_catchattack()
        {

        }

        public virtual void anm_catchcut()
        {

        }

        public virtual void anm_catchdash()
        {
            Catch();
        }

        public virtual void anm_catchpull()
        {

        }

        public virtual void anm_catchturn()
        {
            Catch(5,true);
        }

        public virtual void anm_catchwait()
        {

        }

        public virtual void anm_throwb()
        {

        }

        public virtual void anm_throwf()
        {

        }

        public virtual void anm_throwhi()
        {

        }

        public virtual void anm_throwlw()
        {

        }

        public virtual void anm_thrownb()
        {

        }

        public virtual void anm_thrownbigb()
        {

        }

        public virtual void anm_thrownbigf()
        {

        }

        public virtual void anm_thrownbighi()
        {

        }

        public virtual void anm_thrownbiglw()
        {

        }

        public virtual void anm_throwndxb()
        {

        }

        public virtual void anm_throwndxf()
        {

        }

        public virtual void anm_throwndxhi()
        {

        }

        public virtual void anm_throwndxlw()
        {

        }

        public virtual void anm_thrownf()
        {

        }

        public virtual void anm_throwngirlb()
        {

        }

        public virtual void anm_throwngirlf()
        {

        }

        public virtual void anm_throwngirlhi()
        {

        }

        public virtual void anm_throwngirllw()
        {

        }

        public virtual void anm_thrownhi()
        {

        }

        public virtual void anm_thrownlw()
        {

        }

        public virtual void anm_capturedamagehi()
        {

        }

        public virtual void anm_capturepulledhi()
        {

        }

        public virtual void anm_capturewaithi()
        {

        }

        public virtual void anm_capturecut()
        {

        }

        public virtual void anm_capturedamagelw()
        {

        }

        public virtual void anm_capturejump()
        {

        }

        public virtual void anm_capturepulledlw()
        {

        }

        public virtual void anm_capturewaitlw()
        {

        }

        public virtual void anm_damagehi1()
        {

        }

        public virtual void anm_damagehi2()
        {

        }

        public virtual void anm_damagehi3()
        {

        }

        public virtual void anm_damagelw1()
        {

        }

        public virtual void anm_damagelw2()
        {

        }

        public virtual void anm_damagelw3()
        {

        }

        public virtual void anm_damagen1()
        {
            DamageN();
        }

        public virtual void anm_damagen2()
        {
            DamageN();
        }

        public virtual void anm_damagen3()
        {
            DamageN();
        }

        public virtual void anm_damageair1()
        {
            DamageN();
        }

        public virtual void anm_damageair2()
        {
            DamageN();
        }

        public virtual void anm_damageair3()
        {
            DamageN();
        }

        public virtual void anm_damageflyhi()
        {

        }

        public virtual void anm_damageflylw()
        {

        }

        public virtual void anm_damageflymeteor()
        {
            WhenFinishedGoTo("damagefall",20);
        }

        public virtual void anm_damageflyn()
        {
            WhenFinishedGoTo("damagefall",20);
        }

        public virtual void anm_damageflyroll()
        {

        }

        public virtual void anm_damageflyrollend()
        {
            WhenFinishedGoTo("damagefall",100);

            DamageFlyTurn(phy.Velocity);
        }

        public virtual void anm_damageflytop()
        {
            WhenFinishedGoTo("damagefall",100);
        }

        public virtual void anm_damageelec()
        {

        }

        public virtual void anm_downattacku()
        {

        }

        public virtual void anm_downbacku()
        {

        }

        public virtual void anm_downboundu()
        {
            DownBound();
        }

        public virtual void anm_downdamageu()
        {

        }

        public virtual void anm_downdamageu3()
        {

        }

        public virtual void anm_downeatu()
        {

        }

        public virtual void anm_downforwardu()
        {

        }

        public virtual void anm_downstandu()
        {
            DownStand();
        }

        public virtual void anm_downwaitu()
        {
            DownWait();
        }

        public virtual void anm_downattackd()
        {

        }

        public virtual void anm_downbackd()
        {

        }

        public virtual void anm_downboundd()
        {
            DownBound();
        }

        public virtual void anm_downdamaged()
        {

        }

        public virtual void anm_downdamaged3()
        {

        }

        public virtual void anm_downeatd()
        {

        }

        public virtual void anm_downforwardd()
        {

        }

        public virtual void anm_downspotd()
        {

        }

        public virtual void anm_downstandd()
        {
            DownStand();
        }

        public virtual void anm_downwaitd()
        {
            DownWait();
        }

        public virtual void anm_passive()
        {

        }

        public virtual void anm_passiveceil()
        {

        }

        public virtual void anm_passivestandb()
        {

        }

        public virtual void anm_passivestandf()
        {

        }

        public virtual void anm_passivewall()
        {

        }

        public virtual void anm_passivewalljump()
        {

        }

        public virtual void anm_furafura()
        {

        }

        public virtual void anm_furafuraend()
        {

        }

        public virtual void anm_furafurastartd()
        {

        }

        public virtual void anm_furafurastartu()
        {

        }

        public virtual void anm_sleepend()
        {

        }

        public virtual void anm_sleeploop()
        {

        }

        public virtual void anm_sleepstart()
        {

        }

        public virtual void anm_swallowed()
        {

        }

        public virtual void anm_ceildamage()
        {

        }

        public virtual void anm_missfoot()
        {

        }

        public virtual void anm_ottotto()
        {
            Wait();

            WhenFinishedGoTo("ottottowait");
        }

        public virtual void anm_ottottowait()
        {
            Wait();

            if (!phy.Ottotto)
            {
                anim.CrossFade("wait1",20);
            }
        }

        public virtual void anm_pass()
        {

        }

        public virtual void anm_stopceil()
        {
            if (anim.CurrentKeyIndex <= 15)
            {
                phy.Velocity.Y = 0;

                phy.MoveX(0, 5);
            }

            WhenFinishedGoTo("fall");
        }

        public virtual void anm_stopwall()
        {
            WhenFinishedGoTo("wait1");
        }

        public virtual void anm_walldamage()
        {

        }

        public virtual void anm_cliffcatch()
        {
            WhenFinishedGoTo("cliffwait");

            phy.LeftRightCollision = false;
            phy.TopDownCollision = false;
        }

        public virtual void anm_cliffwait()
        {
            if (HeldLedge != null)
            {
                if (input.Ydir == -1 || input.Cdir == HeldLedge.Direction)
                {
                    AirVelocityEverPositive = false;
                    anim.CrossFade("fall", 50);
                    HeldLedge.Release();
                }
                else if (input.Cdir == -HeldLedge.Direction)
                {
                    AirVelocityEverPositive = false;
                    anim.CrossFade("cliffescape");
                    skeleton.RootNode.LocalPosition = new Vector3(skeleton.RootNode.LocalPosition.X, skeleton.RootNode.LocalPosition.Y, 0);
                    HeldLedge.Release();
                }
                else if (input.JumpButton.Buffered || input.Ydir == 1)
                {
                    anim.CrossFade("cliffjump1", 50);
                }

                Jumps = Peram.JumpCount;

                phy.LeftRightCollision = false;
                phy.TopDownCollision = false;
            }
        }

        public virtual void anm_cliffattack()
        {

        }

        public virtual void anm_cliffclimb()
        {

        }

        public virtual void anm_cliffescape()
        {
            WhenFinishedGoTo("wait1");

            phy.SnapToGround(1);

            Landed = true;

            AirVelocityEverPositive = false;
            phy.LeftRightCollision = false;
            phy.TopDownCollision = false;

            phy.HugLedge();

            MoveInAnimation();
        }

        public virtual void anm_cliffjump1()
        {
            if (anim.FinishedAnimation)
            {
                HeldLedge.Release();
                phy.Velocity.Y = Peram.JumpHeight;
            }

            WhenFinishedGoTo("cliffjump2");
        }

        public virtual void anm_cliffjump2()
        {
            WhenFinishedGoTo("fall");
        }

        public virtual void anm_slip()
        {

        }

        public virtual void anm_slipattack()
        {

        }

        public virtual void anm_slipdown()
        {

        }

        public virtual void anm_slipescapeb()
        {

        }

        public virtual void anm_slipescapef()
        {

        }

        public virtual void anm_slipstand()
        {

        }

        public virtual void anm_slipwait()
        {

        }

        public virtual void anm_lighteat()
        {

        }

        public virtual void anm_lightget()
        {

        }

        public virtual void anm_lightwalkeat()
        {

        }

        public virtual void anm_lightwalkget()
        {

        }

        public virtual void anm_lightthrowb()
        {

        }

        public virtual void anm_lightthrowdash()
        {

        }

        public virtual void anm_lightthrowdrop()
        {

        }

        public virtual void anm_lightthrowf()
        {

        }

        public virtual void anm_lightthrowhi()
        {

        }

        public virtual void anm_lightthrowlw()
        {

        }

        public virtual void anm_lightthrowairb()
        {

        }

        public virtual void anm_lightthrowairf()
        {

        }

        public virtual void anm_lightthrowairhi()
        {

        }

        public virtual void anm_lightthrowairlw()
        {

        }

        public virtual void anm_heavyget()
        {

        }

        public virtual void anm_heavythrowb()
        {

        }

        public virtual void anm_heavythrowf()
        {

        }

        public virtual void anm_heavythrowhi()
        {

        }

        public virtual void anm_heavythrowlw()
        {

        }

        public virtual void anm_heavywalk()
        {

        }

        public virtual void anm_swing1()
        {

        }

        public virtual void anm_swing3()
        {

        }

        public virtual void anm_swing4()
        {

        }

        public virtual void anm_swing4charge()
        {

        }

        public virtual void anm_swingdash()
        {

        }

        public virtual void anm_itemhammerair()
        {

        }

        public virtual void anm_itemhammermove()
        {

        }

        public virtual void anm_itemhammerwait()
        {

        }

        public virtual void anm_swing4bat()
        {

        }

        public virtual void anm_itemscrew()
        {

        }

        public virtual void anm_itemscrewfall()
        {

        }

        public virtual void anm_itemdragoonget()
        {

        }

        public virtual void anm_itemdragoonride()
        {

        }

        public virtual void anm_itemlegsjumpsquat()
        {

        }

        public virtual void anm_itemlegslanding()
        {

        }

        public virtual void anm_itemlegswalkb()
        {

        }

        public virtual void anm_itemlegswalkf()
        {

        }

        public virtual void anm_itemshoot()
        {

        }

        public virtual void anm_itemshootair()
        {

        }

        public virtual void anm_itemshootairloop()
        {

        }

        public virtual void anm_itemshootloop()
        {

        }

        public virtual void anm_itemshootloopupper()
        {

        }

        public virtual void anm_itemshootupper()
        {

        }

        public virtual void anm_itemscopeairend()
        {

        }

        public virtual void anm_itemscopeairfire()
        {

        }

        public virtual void anm_itemscopeairrapid()
        {

        }

        public virtual void anm_itemscopeairstart()
        {

        }

        public virtual void anm_itemscopeend()
        {

        }

        public virtual void anm_itemscopeendupper()
        {

        }

        public virtual void anm_itemscopefall()
        {

        }

        public virtual void anm_itemscopefire()
        {

        }

        public virtual void anm_itemscopefireupper()
        {

        }

        public virtual void anm_itemscoperapid()
        {

        }

        public virtual void anm_itemscoperapidupper()
        {

        }

        public virtual void anm_itemscopestart()
        {

        }

        public virtual void anm_itemscopestartupper()
        {

        }

        public virtual void anm_itemscopewait()
        {

        }

        public virtual void anm_itemscopewaitupper()
        {

        }

        public virtual void anm_itemassist()
        {

        }

        public virtual void anm_gekikarawait()
        {

        }

        public virtual void anm_gekikarawaitface()
        {

        }

        public virtual void anm_itemgrasspull()
        {

        }

        public virtual void anm_itemgenesisairend()
        {

        }

        public virtual void anm_itemgenesisairfire()
        {

        }

        public virtual void anm_itemgenesisairloop()
        {

        }

        public virtual void anm_itemgenesisend()
        {

        }

        public virtual void anm_itemgenesisfall()
        {

        }

        public virtual void anm_itemgenesisfire()
        {

        }

        public virtual void anm_itemgenesisloop()
        {

        }

        public virtual void anm_itemgenesisturn()
        {

        }

        public virtual void anm_itemgenesiswait()
        {

        }

        public virtual void anm_itemgenesiswaitupper()
        {

        }

        public virtual void anm_swim()
        {

        }

        public virtual void anm_swimend()
        {

        }

        public virtual void anm_swimf()
        {

        }

        public virtual void anm_swimrise()
        {

        }

        public virtual void anm_swimturn()
        {

        }

        public virtual void anm_swimup()
        {

        }

        public virtual void anm_swimupdamage()
        {

        }

        public virtual void anm_swimdrown()
        {

        }

        public virtual void anm_swimdrownout()
        {

        }

        public virtual void anm_entryl()
        {
            Entry();
        }

        public virtual void anm_entryr()
        {
            Entry();
        }

        public virtual void anm_appealhil()
        {

        }

        public virtual void anm_appealhir()
        {

        }

        public virtual void anm_appeallwr()
        {

        }

        public virtual void anm_appealsr()
        {

        }

        public virtual void anm_lose()
        {

        }

        public virtual void anm_win1_us_en()
        {

        }

        public virtual void anm_win1wait_us_en()
        {

        }

        public virtual void anm_win2_us_en()
        {

        }

        public virtual void anm_win2a_us_en()
        {

        }

        public virtual void anm_win2await_us_en()
        {

        }

        public virtual void anm_win2b_us_en()
        {

        }

        public virtual void anm_win2bwait_us_en()
        {

        }

        public virtual void anm_win2wait_us_en()
        {

        }

        public virtual void anm_win3_us_en()
        {

        }

        public virtual void anm_win3a_us_en()
        {

        }

        public virtual void anm_win3await_us_en()
        {

        }

        public virtual void anm_win3b_us_en()
        {

        }

        public virtual void anm_win3bwait_us_en()
        {

        }

        public virtual void anm_win3wait_us_en()
        {

        }

        public virtual void anm_laddercatchairl()
        {

        }

        public virtual void anm_laddercatchairr()
        {

        }

        public virtual void anm_laddercatchendl()
        {

        }

        public virtual void anm_laddercatchendr()
        {

        }

        public virtual void anm_laddercatchl()
        {

        }

        public virtual void anm_laddercatchr()
        {

        }

        public virtual void anm_ladderdown()
        {

        }

        public virtual void anm_ladderup()
        {

        }

        public virtual void anm_ladderwait()
        {

        }

        public virtual void anm_hair()
        {

        }

        public virtual void anm_share()
        {

        }

        public virtual void anm_share_cliff()
        {

        }

        public virtual void anm_share_finish()
        {

        }

        public virtual void anm_share_sleep()
        {

        }

        public virtual void anm_wait2()
        {
            Wait();
        }

        public virtual void anm_shieldguard()
        {

        }

        public virtual void anm_attacks3s()
        {
            GroundAttack();
        }

        public virtual void anm_specialairn1()
        {

        }

        public virtual void anm_specialairn2()
        {

        }

        public virtual void anm_specialairn3()
        {

        }

        public virtual void anm_specialairncancel()
        {

        }

        public virtual void anm_specialairnhold()
        {

        }

        public virtual void anm_specialairnstart()
        {

        }

        public virtual void anm_specialn1()
        {

        }

        public virtual void anm_specialn2()
        {

        }

        public virtual void anm_specialn3()
        {

        }

        public virtual void anm_specialncancel()
        {

        }

        public virtual void anm_specialnhold()
        {

        }

        public virtual void anm_specialnstart()
        {

        }

        public virtual void anm_specialairs1()
        {

        }

        public virtual void anm_specialairs2()
        {

        }

        public virtual void anm_specialairs3()
        {

        }

        public virtual void anm_specialairs32()
        {

        }

        public virtual void anm_specialairshold()
        {

        }

        public virtual void anm_specialairsstart()
        {

        }

        public virtual void anm_specials1()
        {

        }

        public virtual void anm_specials2()
        {

        }

        public virtual void anm_specials3()
        {

        }

        public virtual void anm_specials32()
        {

        }

        public virtual void anm_specialshold()
        {

        }

        public virtual void anm_specialsstart()
        {

        }

        public virtual void anm_specialairhi1()
        {

        }

        public virtual void anm_specialairhi2()
        {

        }

        public virtual void anm_specialairhi3()
        {

        }

        public virtual void anm_specialairhiempty()
        {

        }

        public virtual void anm_specialairhihold()
        {

        }

        public virtual void anm_specialairhistart()
        {

        }

        public virtual void anm_specialhi1()
        {

        }

        public virtual void anm_specialhi2()
        {

        }

        public virtual void anm_specialhi3()
        {

        }

        public virtual void anm_specialhiempty()
        {

        }

        public virtual void anm_specialhihold()
        {

        }

        public virtual void anm_specialhistart()
        {

        }

        public virtual void anm_specialairlwcancel()
        {

        }

        public virtual void anm_specialairlwfail()
        {

        }

        public virtual void anm_specialairlwselect()
        {

        }

        public virtual void anm_specialairlwselect2()
        {

        }

        public virtual void anm_specialairlwskill1()
        {

        }

        public virtual void anm_specialairlwskill2()
        {

        }

        public virtual void anm_specialairlwskill3()
        {

        }

        public virtual void anm_specialairlwskill4()
        {

        }

        public virtual void anm_specialairlwspell1()
        {

        }

        public virtual void anm_specialairlwspell10end()
        {

        }

        public virtual void anm_specialairlwspell10loop()
        {

        }

        public virtual void anm_specialairlwspell10start()
        {

        }

        public virtual void anm_specialairlwspell2()
        {

        }

        public virtual void anm_specialairlwspell3()
        {

        }

        public virtual void anm_specialairlwspell4()
        {

        }

        public virtual void anm_specialairlwspell5()
        {

        }

        public virtual void anm_specialairlwspell6()
        {

        }

        public virtual void anm_specialairlwspell7()
        {

        }

        public virtual void anm_specialairlwspell8()
        {

        }

        public virtual void anm_specialairlwspell9start()
        {

        }

        public virtual void anm_specialairlwstart()
        {

        }

        public virtual void anm_speciallwcancel()
        {

        }

        public virtual void anm_speciallwfail()
        {

        }

        public virtual void anm_speciallwlanding()
        {

        }

        public virtual void anm_speciallwselect()
        {

        }

        public virtual void anm_speciallwselect2()
        {

        }

        public virtual void anm_speciallwskill1()
        {

        }

        public virtual void anm_speciallwskill2()
        {

        }

        public virtual void anm_speciallwskill3()
        {

        }

        public virtual void anm_speciallwskill4()
        {

        }

        public virtual void anm_speciallwspell1()
        {

        }

        public virtual void anm_speciallwspell10end()
        {

        }

        public virtual void anm_speciallwspell10loop()
        {

        }

        public virtual void anm_speciallwspell10start()
        {

        }

        public virtual void anm_speciallwspell2()
        {

        }

        public virtual void anm_speciallwspell3()
        {

        }

        public virtual void anm_speciallwspell4()
        {

        }

        public virtual void anm_speciallwspell5()
        {

        }

        public virtual void anm_speciallwspell6()
        {

        }

        public virtual void anm_speciallwspell7()
        {

        }

        public virtual void anm_speciallwspell8()
        {

        }

        public virtual void anm_speciallwspell9end()
        {

        }

        public virtual void anm_speciallwspell9hi()
        {

        }

        public virtual void anm_speciallwspell9lw()
        {

        }

        public virtual void anm_speciallwspell9start()
        {

        }

        public virtual void anm_speciallwstart()
        {

        }

        public virtual void anm_finalairend()
        {

        }

        public virtual void anm_finalairstart()
        {

        }

        public virtual void anm_finalend()
        {

        }

        public virtual void anm_finalstart()
        {

        }

        public virtual void anm_visualscene01()
        {

        }

        public virtual void anm_appeallwl()
        {

        }

        public virtual void anm_appealsl()
        {

        }

        public virtual void anm_win1()
        {

        }

        public virtual void anm_win1wait()
        {

        }

        public virtual void anm_win2()
        {

        }

        public virtual void anm_win2wait()
        {

        }

        public virtual void anm_win3()
        {

        }

        public virtual void anm_win3wait()
        {

        }

        public virtual void anm_runstart()
        {

        }

        public virtual void anm_jumpaerialf1()
        {

        }

        public virtual void anm_jumpaerialf2()
        {

        }

        public virtual void anm_attacks3hi()
        {

        }

        public virtual void anm_attacks3lw()
        {

        }

        public virtual void anm_specialairnend()
        {

        }

        public virtual void anm_specialairnfire()
        {

        }

        public virtual void anm_specialairnfire2()
        {

        }

        public virtual void anm_specialairnfire3()
        {

        }

        public virtual void anm_specialairnturn()
        {

        }

        public virtual void anm_specialnend()
        {

        }

        public virtual void anm_specialnfall()
        {

        }

        public virtual void anm_specialnfire()
        {

        }

        public virtual void anm_specialnfire2()
        {

        }

        public virtual void anm_specialnjump()
        {

        }

        public virtual void anm_specialnjumpaerialf1()
        {

        }

        public virtual void anm_specialnturn()
        {

        }

        public virtual void anm_specialnupperfire()
        {

        }

        public virtual void anm_specialnupperwait()
        {

        }

        public virtual void anm_specialnwait()
        {

        }

        public virtual void anm_specialairsdash()
        {

        }

        public virtual void anm_specialairsend()
        {

        }

        public virtual void anm_specialairsfail()
        {

        }

        public virtual void anm_specialairswall()
        {

        }

        public virtual void anm_specialsdash()
        {

        }

        public virtual void anm_specialsend()
        {

        }

        public virtual void anm_specialsfail()
        {

        }

        public virtual void anm_specialswall()
        {

        }

        public virtual void anm_visualscene02()
        {

        }

        public virtual void anm_visualscene03()
        {

        }

        public virtual void anm_visualscene04()
        {

        }

        public virtual void anm_specialairn()
        {

        }

        public virtual void anm_specialn()
        {

        }

        public virtual void anm_specialairs()
        {

        }

        public virtual void anm_specialhicapture()
        {

        }

        public virtual void anm_specialhicatch()
        {

        }

        public virtual void anm_specialhidxcapture()
        {

        }

        public virtual void anm_specialhigirlcapture()
        {

        }

        public virtual void anm_specialhithrow()
        {

        }

        public virtual void anm_specialairlwend()
        {

        }

        public virtual void anm_specialairlwendair()
        {

        }

        public virtual void anm_speciallwend()
        {

        }

        public virtual void anm_speciallwendair()
        {

        }

        public virtual void anm_speciallwwallhit()
        {

        }

        public virtual void anm_finalairridel()
        {

        }

        public virtual void anm_finalairrider()
        {

        }

        public virtual void anm_finalridel()
        {

        }

        public virtual void anm_finalrider()
        {

        }

        public virtual void anm_specialairnloop()
        {

        }

        public virtual void anm_specialnloop()
        {

        }

        public virtual void anm_specialairs2hi()
        {

        }

        public virtual void anm_specialairs2lw()
        {

        }

        public virtual void anm_specialairs3hi()
        {

        }

        public virtual void anm_specialairs3lw()
        {

        }

        public virtual void anm_specialairs3s()
        {

        }

        public virtual void anm_specialairs4hi()
        {

        }

        public virtual void anm_specialairs4lw()
        {

        }

        public virtual void anm_specialairs4s()
        {

        }

        public virtual void anm_specials2hi()
        {

        }

        public virtual void anm_specials2lw()
        {

        }

        public virtual void anm_specials3hi()
        {

        }

        public virtual void anm_specials3lw()
        {

        }

        public virtual void anm_specials3s()
        {

        }

        public virtual void anm_specials4hi()
        {

        }

        public virtual void anm_specials4lw()
        {

        }

        public virtual void anm_specials4s()
        {

        }

        public virtual void anm_specialhi4()
        {

        }

        public virtual void anm_specialairlwhit()
        {

        }

        public virtual void anm_speciallwhit()
        {

        }

        public virtual void anm_finalairattack()
        {

        }

        public virtual void anm_finalairdashend()
        {

        }

        public virtual void anm_finalattack()
        {

        }

        public virtual void anm_finaldash()
        {

        }

        public virtual void anm_finaldashend()
        {

        }

        public virtual void anm_downspotu()
        {

        }

        public virtual void anm_win1a_us_en()
        {

        }

        public virtual void anm_win1await_us_en()
        {

        }

        public virtual void anm_win1b_us_en()
        {

        }

        public virtual void anm_win1bwait_us_en()
        {

        }

        public virtual void anm_specialhifall()
        {

        }

        public virtual void anm_specialhifallend()
        {

        }

        public virtual void anm_specialhilanding()
        {

        }

        public virtual void anm_specialairlwjumpcancel()
        {

        }

        public virtual void anm_specialairlwlanding()
        {

        }

        public virtual void anm_specialairlwloop()
        {

        }

        public virtual void anm_speciallwloop()
        {

        }

        public virtual void anm_finalairhit()
        {

        }

        public virtual void anm_finalfall()
        {

        }

        public virtual void anm_finalhit()
        {

        }

        public virtual void anm_finalmove()
        {

        }

        public virtual void anm_specialairnhit()
        {

        }

        public virtual void anm_specialnhit()
        {

        }

        public virtual void anm_specialsjump()
        {

        }

        public virtual void anm_specialairhiend()
        {

        }

        public virtual void anm_specialhiopen()
        {

        }

        public virtual void anm_fuwafuwa()
        {

        }

        public virtual void anm_fuwafuwastart()
        {

        }

        public virtual void anm_jumpaerialf3()
        {

        }

        public virtual void anm_jumpaerialf4()
        {

        }

        public virtual void anm_specialairnbomb()
        {

        }

        public virtual void anm_specialairneat()
        {

        }

        public virtual void anm_specialairneatjump1()
        {

        }

        public virtual void anm_specialairneatjump2()
        {

        }

        public virtual void anm_specialairnfood()
        {

        }

        public virtual void anm_specialairnlarge()
        {

        }

        public virtual void anm_specialairnspit()
        {

        }

        public virtual void anm_specialairnswallow()
        {

        }

        public virtual void anm_specialnbomb()
        {

        }

        public virtual void anm_specialneat()
        {

        }

        public virtual void anm_specialneatfall()
        {

        }

        public virtual void anm_specialneatlanding()
        {

        }

        public virtual void anm_specialneatturn()
        {

        }

        public virtual void anm_specialneatwait()
        {

        }

        public virtual void anm_specialneatwalkfast()
        {

        }

        public virtual void anm_specialneatwalkmiddle()
        {

        }

        public virtual void anm_specialneatwalkslow()
        {

        }

        public virtual void anm_specialnfood()
        {

        }

        public virtual void anm_specialnlarge()
        {

        }

        public virtual void anm_specialnspit()
        {

        }

        public virtual void anm_specialnswallow()
        {

        }

        public virtual void anm_specialairsget()
        {

        }

        public virtual void anm_specialsget()
        {

        }

        public virtual void anm_specialairhiturnl()
        {

        }

        public virtual void anm_specialairhiturnr()
        {

        }

        public virtual void anm_specialhifailure()
        {

        }

        public virtual void anm_specialhihit()
        {

        }

        public virtual void anm_specialhijump()
        {

        }

        public virtual void anm_specialhilandingl()
        {

        }

        public virtual void anm_specialhilandingr()
        {

        }

        public virtual void anm_specialhiloop()
        {

        }

        public virtual void anm_specialhistartl()
        {

        }

        public virtual void anm_specialhistartr()
        {

        }

        public virtual void anm_specialairlwmax()
        {

        }

        public virtual void anm_speciallwfall()
        {

        }

        public virtual void anm_speciallwhold()
        {

        }

        public virtual void anm_speciallwholdmax()
        {

        }

        public virtual void anm_speciallwjump()
        {

        }

        public virtual void anm_speciallwjumpsquat()
        {

        }

        public virtual void anm_speciallwmax()
        {

        }

        public virtual void anm_speciallwturn()
        {

        }

        public virtual void anm_speciallwwalk()
        {

        }

        public virtual void anm_finalvisualscene02()
        {

        }

        public virtual void anm_finalvisualscene03()
        {

        }

        public virtual void anm_squatb()
        {

        }

        public virtual void anm_squatf()
        {

        }

        public virtual void anm_specialairnblow()
        {

        }

        public virtual void anm_specialairncharge()
        {

        }

        public virtual void anm_specialairndanger()
        {

        }

        public virtual void anm_specialairnshoot()
        {

        }

        public virtual void anm_specialnblow()
        {

        }

        public virtual void anm_specialncharge()
        {

        }

        public virtual void anm_specialndanger()
        {

        }

        public virtual void anm_specialnshoot()
        {

        }

        public virtual void anm_specialairsfall()
        {

        }

        public virtual void anm_specialairsjump()
        {

        }

        public virtual void anm_specialairskick()
        {

        }

        public virtual void anm_specialskicklanding()
        {

        }

        public virtual void anm_specialslanding()
        {

        }

        public virtual void anm_specialsstick()
        {

        }

        public virtual void anm_specialsstickattack()
        {

        }

        public virtual void anm_specialsstickattack2()
        {

        }

        public virtual void anm_specialsstickjump()
        {

        }

        public virtual void anm_specialsstickjump2()
        {

        }

        public virtual void anm_specialairhicharge()
        {

        }

        public virtual void anm_specialairhichargeb()
        {

        }

        public virtual void anm_specialairhichargef()
        {

        }

        public virtual void anm_specialairhidamage()
        {

        }

        public virtual void anm_specialairhijdamage()
        {

        }

        public virtual void anm_specialairhijump()
        {

        }

        public virtual void anm_specialhicharge()
        {

        }

        public virtual void anm_specialhichargeb()
        {

        }

        public virtual void anm_specialhichargef()
        {

        }

        public virtual void anm_specialairlwmiss()
        {

        }

        public virtual void anm_speciallwmiss()
        {

        }

        public virtual void anm_finalcharge()
        {

        }

        public virtual void anm_finalfinishhi()
        {

        }

        public virtual void anm_finalfinishlw()
        {

        }

        public virtual void anm_finalfinishs()
        {

        }

        public virtual void anm_finalhi()
        {

        }

        public virtual void anm_finallw()
        {

        }

        public virtual void anm_finals()
        {

        }

        public virtual void anm_finalstarthi()
        {

        }

        public virtual void anm_specialsdxstickattackcapture()
        {

        }

        public virtual void anm_specialsdxstickcapture()
        {

        }

        public virtual void anm_specialsdxstickjumpcapture()
        {

        }

        public virtual void anm_specialsgirlstickattackcapture()
        {

        }

        public virtual void anm_specialsgirlstickcapture()
        {

        }

        public virtual void anm_specialsgirlstickjumpcapture()
        {

        }

        public virtual void anm_specialsstickattackcapture()
        {

        }

        public virtual void anm_specialsstickcapture()
        {

        }

        public virtual void anm_specialsstickjumpcapture()
        {

        }

        public virtual void anm_walkbrakelb()
        {

        }

        public virtual void anm_walkbrakerb()
        {

        }

        public virtual void anm_walkfastb()
        {

        }

        public virtual void anm_walkmiddleb()
        {

        }

        public virtual void anm_walkslowb()
        {

        }

        public virtual void anm_dashb()
        {

        }

        public virtual void anm_dashbrun()
        {

        }

        public virtual void anm_walkfalllb()
        {

        }

        public virtual void anm_walkfallrb()
        {

        }

        public virtual void anm_specialairsbend()
        {

        }

        public virtual void anm_specialairsbstart()
        {

        }

        public virtual void anm_specialairsfend()
        {

        }

        public virtual void anm_specialairsfstart()
        {

        }

        public virtual void anm_specialsbend()
        {

        }

        public virtual void anm_specialsbs()
        {

        }

        public virtual void anm_specialsbstart()
        {

        }

        public virtual void anm_specialsbw()
        {

        }

        public virtual void anm_specialsf()
        {

        }

        public virtual void anm_specialsfend()
        {

        }

        public virtual void anm_specialsfstart()
        {

        }

        public virtual void anm_specialairlwrise()
        {

        }

        public virtual void anm_specialairlwrisew()
        {

        }

        public virtual void anm_superspecial1()
        {

        }

        public virtual void anm_superspecial2()
        {

        }

        public virtual void anm_superspecial2start()
        {

        }

        public virtual void anm_visualscene05()
        {

        }

        public virtual void anm_capshadow()
        {

        }

        public virtual void anm_specialairnjumpcancel()
        {

        }

        public virtual void anm_throwfb()
        {

        }

        public virtual void anm_throwff()
        {

        }

        public virtual void anm_throwffall()
        {

        }

        public virtual void anm_throwfhi()
        {

        }

        public virtual void anm_throwfjump()
        {

        }

        public virtual void anm_throwfjumpsquat()
        {

        }

        public virtual void anm_throwflanding()
        {

        }

        public virtual void anm_throwflw()
        {

        }

        public virtual void anm_throwfturn()
        {

        }

        public virtual void anm_throwfwait()
        {

        }

        public virtual void anm_throwfwalkfast()
        {

        }

        public virtual void anm_throwfwalkmiddle()
        {

        }

        public virtual void anm_throwfwalkslow()
        {

        }

        public virtual void anm_thrownbigfb()
        {

        }

        public virtual void anm_thrownbigff()
        {

        }

        public virtual void anm_throwndxfb()
        {

        }

        public virtual void anm_throwndxff()
        {

        }

        public virtual void anm_throwndxfhi()
        {

        }

        public virtual void anm_throwndxflw()
        {

        }

        public virtual void anm_throwndxzitabata()
        {

        }

        public virtual void anm_thrownfb()
        {

        }

        public virtual void anm_thrownff()
        {

        }

        public virtual void anm_thrownfhi()
        {

        }

        public virtual void anm_thrownflw()
        {

        }

        public virtual void anm_throwngirlfb()
        {

        }

        public virtual void anm_throwngirlff()
        {

        }

        public virtual void anm_throwngirlfhi()
        {

        }

        public virtual void anm_throwngirlflw()
        {

        }

        public virtual void anm_throwngirlzitabata()
        {

        }

        public virtual void anm_thrownzitabata()
        {

        }

        public virtual void anm_heavyfall()
        {

        }

        public virtual void anm_heavyjump()
        {

        }

        public virtual void anm_heavyjumpsquat()
        {

        }

        public virtual void anm_heavylanding()
        {

        }

        public virtual void anm_heavyturn()
        {

        }

        public virtual void anm_heavywait()
        {

        }

        public virtual void anm_heavywalkfast()
        {

        }

        public virtual void anm_heavywalkmiddle()
        {

        }

        public virtual void anm_heavywalkslow()
        {

        }

        public virtual void anm_share_specialnmax()
        {

        }

        public virtual void anm_specialhiend()
        {

        }

        public virtual void anm_finalairready()
        {

        }

        public virtual void anm_finalready()
        {

        }

        public virtual void anm_itemrocketbelt()
        {

        }

        public virtual void anm_closingear()
        {

        }

        public virtual void anm_specialsfalllanding()
        {

        }

        public virtual void anm_specialhibound()
        {

        }

        public virtual void anm_specialhiholdair()
        {

        }

        public virtual void anm_specialairlwr()
        {

        }

        public virtual void anm_speciallwr()
        {

        }

        public virtual void anm_finalairlockon()
        {

        }

        public virtual void anm_finallockon()
        {

        }

        public virtual void anm_finalvisualscene()
        {

        }

        public virtual void anm_appealsendl()
        {

        }

        public virtual void anm_appealsendr()
        {

        }

        public virtual void anm_appealsstartl()
        {

        }

        public virtual void anm_appealsstartr()
        {

        }

        public virtual void anm_specialairlwendl()
        {

        }

        public virtual void anm_specialairlwhitl()
        {

        }

        public virtual void anm_specialairlwloopl()
        {

        }

        public virtual void anm_specialairlwstartl()
        {

        }

        public virtual void anm_speciallwendl()
        {

        }

        public virtual void anm_speciallwhitl()
        {

        }

        public virtual void anm_speciallwloopl()
        {

        }

        public virtual void anm_speciallwstartl()
        {

        }

        public virtual void anm_attackhi3l()
        {

        }

        public virtual void anm_attackhi4r()
        {

        }

        public virtual void anm_attackhi4rcharge()
        {

        }

        public virtual void anm_specialairsl()
        {

        }

        public virtual void anm_specialsl()
        {

        }

        public virtual void anm_specialhiclose()
        {

        }

        public virtual void anm_specialairlwcatch()
        {

        }

        public virtual void anm_specialairlwshoot()
        {

        }

        public virtual void anm_speciallwcatch()
        {

        }

        public virtual void anm_speciallwshoot()
        {

        }

        public virtual void anm_specialairscatch()
        {

        }

        public virtual void anm_ganonspecialhicapture()
        {

        }

        public virtual void anm_ganonspecialhidxcapture()
        {

        }

        public virtual void anm_ganonspecialhigirlcapture()
        {

        }

        public virtual void anm_specialairscapture()
        {

        }

        public virtual void anm_specialairscatchcapture()
        {

        }

        public virtual void anm_specialairsdxcapture()
        {

        }

        public virtual void anm_specialairsdxcatchcapture()
        {

        }

        public virtual void anm_specialairsdxfallcapture()
        {

        }

        public virtual void anm_specialairsfallcapture()
        {

        }

        public virtual void anm_specialairsgirlcapture()
        {

        }

        public virtual void anm_specialairsgirlcatchcapture()
        {

        }

        public virtual void anm_specialairsgirlfallcapture()
        {

        }

        public virtual void anm_specialscapture()
        {

        }

        public virtual void anm_specialsdxcapture()
        {

        }

        public virtual void anm_specialsgirlcapture()
        {

        }

        public virtual void anm_bossentry()
        {

        }

        public virtual void anm_bossentry2()
        {

        }

        public virtual void anm_attack13hit()
        {

        }

        public virtual void anm_attackdashhit()
        {

        }

        public virtual void anm_attacks4shit()
        {

        }

        public virtual void anm_attackhi4hit()
        {

        }

        public virtual void anm_attacklw4hit()
        {

        }

        public virtual void anm_gaogaenspecialsdamage()
        {

        }

        public virtual void anm_gaogaenspecialsdamagebig()
        {

        }

        public virtual void anm_gaogaenspecialsdamagedx()
        {

        }

        public virtual void anm_gaogaenspecialsdamagegirl()
        {

        }

        public virtual void anm_gaogaenspecialsfailure()
        {

        }

        public virtual void anm_gaogaenspecialsfailurebig()
        {

        }

        public virtual void anm_gaogaenspecialsfailuredx()
        {

        }

        public virtual void anm_gaogaenspecialsfailuregirl()
        {

        }

        public virtual void anm_gaogaenspecialsthrown()
        {

        }

        public virtual void anm_gaogaenspecialsthrownbig()
        {

        }

        public virtual void anm_gaogaenspecialsthrowndx()
        {

        }

        public virtual void anm_gaogaenspecialsthrowngirl()
        {

        }

        public virtual void anm_specialairsfailure()
        {

        }

        public virtual void anm_specialairslariat()
        {

        }

        public virtual void anm_specialairsshoulder()
        {

        }

        public virtual void anm_specialairsthrow()
        {

        }

        public virtual void anm_specialsfailure()
        {

        }

        public virtual void anm_specialslariat()
        {

        }

        public virtual void anm_specialsshoulder()
        {

        }

        public virtual void anm_specialsthrow()
        {

        }

        public virtual void anm_specialairhifall()
        {

        }

        public virtual void anm_specialairhiloop()
        {

        }

        public virtual void anm_specialairhiturn()
        {

        }

        public virtual void anm_specialairlwturn()
        {

        }

        public virtual void anm_finalcatch()
        {

        }

        public virtual void anm_gaogaenthrown01()
        {

        }

        public virtual void anm_gaogaenthrown01big()
        {

        }

        public virtual void anm_gaogaenthrown01dx()
        {

        }

        public virtual void anm_gaogaenthrown01girl()
        {

        }

        public virtual void anm_gaogaenthrown02()
        {

        }

        public virtual void anm_gaogaenthrown02big()
        {

        }

        public virtual void anm_gaogaenthrown02dx()
        {

        }

        public virtual void anm_gaogaenthrown02girl()
        {

        }

        public virtual void anm_gaogaenthrown03()
        {

        }

        public virtual void anm_gaogaenthrown03big()
        {

        }

        public virtual void anm_gaogaenthrown03dx()
        {

        }

        public virtual void anm_gaogaenthrown03girl()
        {

        }

        public virtual void anm_specialairnmaxshot()
        {

        }

        public virtual void anm_specialairnshot()
        {

        }

        public virtual void anm_specialnmaxshot()
        {

        }

        public virtual void anm_specialnshot()
        {

        }

        public virtual void anm_specialairsattackb()
        {

        }

        public virtual void anm_specialairsattackf()
        {

        }

        public virtual void anm_specialairsendb()
        {

        }

        public virtual void anm_specialairsendf()
        {

        }

        public virtual void anm_specialsattackb()
        {

        }

        public virtual void anm_specialsattackf()
        {

        }

        public virtual void anm_specialsendb()
        {

        }

        public virtual void anm_specialsendf()
        {

        }

        public virtual void anm_specialairlwattack()
        {

        }

        public virtual void anm_speciallwattack()
        {

        }

        public virtual void anm_speciallwbound()
        {

        }

        public virtual void anm_finalchange()
        {

        }

        public virtual void anm_finalmiss()
        {

        }

        public virtual void anm_specialsairattack()
        {

        }

        public virtual void anm_specialsairdash()
        {

        }

        public virtual void anm_specialsairend()
        {

        }

        public virtual void anm_specialsairhold()
        {

        }

        public virtual void anm_specialsairstart()
        {

        }

        public virtual void anm_specialsattack()
        {

        }

        public virtual void anm_finalairstarthit()
        {

        }

        public virtual void anm_finalairstarthitl()
        {

        }

        public virtual void anm_finalstarthit()
        {

        }

        public virtual void anm_finalstarthitl()
        {

        }

        public virtual void anm_landingfallspeciall()
        {

        }

        public virtual void anm_specialairnfired()
        {

        }

        public virtual void anm_specialairnfiren()
        {

        }

        public virtual void anm_specialairnfireu()
        {

        }

        public virtual void anm_specialnfired()
        {

        }

        public virtual void anm_specialnfiren()
        {

        }

        public virtual void anm_specialnfireu()
        {

        }

        public virtual void anm_specialairsjumpend()
        {

        }

        public virtual void anm_specialairsrun()
        {

        }

        public virtual void anm_specialairsstartempty()
        {

        }

        public virtual void anm_specialairsstopwall()
        {

        }

        public virtual void anm_specialairswalk()
        {

        }

        public virtual void anm_specialairswalkempty()
        {

        }

        public virtual void anm_specialsjumpend()
        {

        }

        public virtual void anm_specialsrun()
        {

        }

        public virtual void anm_specialsrunturn()
        {

        }

        public virtual void anm_specialsstartempty()
        {

        }

        public virtual void anm_specialsstopwall()
        {

        }

        public virtual void anm_specialswalk()
        {

        }

        public virtual void anm_specialswalkempty()
        {

        }

        public virtual void anm_specialswalkturn()
        {

        }

        public virtual void anm_specialairhistartl()
        {

        }

        public virtual void anm_specialairhistartr()
        {

        }

        public virtual void anm_specialhijumpl()
        {

        }

        public virtual void anm_specialhijumpr()
        {

        }

        public virtual void anm_specialhistopceill()
        {

        }

        public virtual void anm_specialhistopceilr()
        {

        }

        public virtual void anm_specialhitopl()
        {

        }

        public virtual void anm_specialhitopr()
        {

        }

        public virtual void anm_specialairlwempty()
        {

        }

        public virtual void anm_specialairlwmiddle()
        {

        }

        public virtual void anm_specialairlwmin()
        {

        }

        public virtual void anm_speciallwempty()
        {

        }

        public virtual void anm_speciallwmiddle()
        {

        }

        public virtual void anm_speciallwmin()
        {

        }

        public virtual void anm_specialinkcharge()
        {

        }

        public virtual void anm_specialinkchargeend()
        {

        }

        public virtual void anm_specialinkchargestart()
        {

        }

        public virtual void anm_red()
        {

        }

        public virtual void anm_yellow()
        {

        }

        public virtual void anm_specialairn1doy()
        {

        }

        public virtual void anm_specialairn2doy()
        {

        }

        public virtual void anm_specialairn3doy()
        {

        }

        public virtual void anm_specialairndown()
        {

        }

        public virtual void anm_specialairndownend()
        {

        }

        public virtual void anm_specialairndownstart()
        {

        }

        public virtual void anm_specialairnescapeb()
        {

        }

        public virtual void anm_specialairnescapebdoy()
        {

        }

        public virtual void anm_specialairnescapef()
        {

        }

        public virtual void anm_specialairnescapefdoy()
        {

        }

        public virtual void anm_specialairnrandom()
        {

        }

        public virtual void anm_specialairnrandomend()
        {

        }

        public virtual void anm_specialairnrandomstart()
        {

        }

        public virtual void anm_specialn1doy()
        {

        }

        public virtual void anm_specialn2doy()
        {

        }

        public virtual void anm_specialn3doy()
        {

        }

        public virtual void anm_specialndownlanding()
        {

        }

        public virtual void anm_specialnescapeb()
        {

        }

        public virtual void anm_specialnescapebdoy()
        {

        }

        public virtual void anm_specialnescapef()
        {

        }

        public virtual void anm_specialnescapefdoy()
        {

        }

        public virtual void anm_specialnjumplanding()
        {

        }

        public virtual void anm_specialnlanding()
        {

        }

        public virtual void anm_specialnrandomlanding()
        {

        }

        public virtual void anm_specialairhib()
        {

        }

        public virtual void anm_specialairhicatch()
        {

        }

        public virtual void anm_specialairhicut()
        {

        }

        public virtual void anm_specialairhiendb()
        {

        }

        public virtual void anm_specialairhiendf()
        {

        }

        public virtual void anm_specialairhif()
        {

        }

        public virtual void anm_specialairhiitem()
        {

        }

        public virtual void anm_specialairhipull()
        {

        }

        public virtual void anm_specialairhipull2()
        {

        }

        public virtual void anm_specialairhithrow()
        {

        }

        public virtual void anm_specialhicut()
        {

        }

        public virtual void anm_specialhiitem()
        {

        }

        public virtual void anm_specialhipull()
        {

        }

        public virtual void anm_specialhipull2()
        {

        }

        public virtual void anm_specialairlw1()
        {

        }

        public virtual void anm_specialairlw2()
        {

        }

        public virtual void anm_specialairlwdamage()
        {

        }

        public virtual void anm_speciallw1()
        {

        }

        public virtual void anm_speciallw2()
        {

        }

        public virtual void anm_speciallwdamage()
        {

        }

        public virtual void anm_finalairdash()
        {

        }

        public virtual void anm_finalairturn()
        {

        }

        public virtual void anm_finalturn()
        {

        }

        public virtual void anm_specialhipulled()
        {

        }

        public virtual void anm_specialhipulledbig()
        {

        }

        public virtual void anm_specialhipulleddx()
        {

        }

        public virtual void anm_specialhipulledgirl()
        {

        }

        public virtual void anm_specialhithrown()
        {

        }

        public virtual void anm_specialhithrownbig()
        {

        }

        public virtual void anm_specialhithrowndx()
        {

        }

        public virtual void anm_specialhithrowngirl()
        {

        }

        public virtual void anm_aircatch()
        {

        }

        public virtual void anm_aircatchhang()
        {

        }

        public virtual void anm_aircatchhit()
        {

        }

        public virtual void anm_aircatchhitloop()
        {

        }

        public virtual void anm_aircatchpose()
        {

        }

        public virtual void anm_win4()
        {

        }

        public virtual void anm_win4wait()
        {

        }

        public virtual void anm_specialairnend1()
        {

        }

        public virtual void anm_specialairnend2()
        {

        }

        public virtual void anm_specialnend1()
        {

        }

        public virtual void anm_specialnend2()
        {

        }

        public virtual void anm_specialairsattack()
        {

        }

        public virtual void anm_specialsattacklanding()
        {

        }

        public virtual void anm_specialsjumplanding()
        {

        }

        public virtual void anm_specialswallattackb()
        {

        }

        public virtual void anm_specialswallattackblanding()
        {

        }

        public virtual void anm_specialswallattackf()
        {

        }

        public virtual void anm_specialswallattackflanding()
        {

        }

        public virtual void anm_specialswallend()
        {

        }

        public virtual void anm_specialswalljump()
        {

        }

        public virtual void anm_specialairlwhitturn()
        {

        }

        public virtual void anm_speciallwhitturn()
        {

        }

        public virtual void anm_uid00specialairnend2()
        {

        }

        public virtual void anm_uid00specialnend2()
        {

        }

        public virtual void anm_wait1b()
        {

        }

        public virtual void anm_wait1f()
        {

        }

        public virtual void anm_justshield()
        {

        }

        public virtual void anm_attack11s()
        {

        }

        public virtual void anm_attack11w()
        {

        }

        public virtual void anm_attacknearw()
        {

        }

        public virtual void anm_attacks3ss()
        {

        }

        public virtual void anm_attacks3sw()
        {

        }

        public virtual void anm_attackhi3s()
        {

        }

        public virtual void anm_attackhi3w()
        {

        }

        public virtual void anm_attacklw3s()
        {

        }

        public virtual void anm_attacklw3w()
        {

        }

        public virtual void anm_specialairnempty()
        {

        }

        public virtual void anm_specialnempty()
        {

        }

        public virtual void anm_specialairlwstepb()
        {

        }

        public virtual void anm_specialairlwstepf()
        {

        }

        public virtual void anm_speciallwstepb()
        {

        }

        public virtual void anm_speciallwstepf()
        {

        }

        public virtual void anm_final2()
        {

        }

        public virtual void anm_final2fall()
        {

        }

        public virtual void anm_final2landing()
        {

        }

        public virtual void anm_finalair2()
        {

        }

        public virtual void anm_finalair2end()
        {

        }

        public virtual void anm_finallanding()
        {

        }

        public virtual void anm_specialcmd1()
        {

        }

        public virtual void anm_specialcmd2()
        {

        }

        public virtual void anm_specialcmd3()
        {

        }

        public virtual void anm_sumi()
        {

        }

        public virtual void anm_jumpaerialf5()
        {

        }

        public virtual void anm_squatwait2()
        {

        }

        public virtual void anm_eatfall()
        {

        }

        public virtual void anm_eatjump1()
        {

        }

        public virtual void anm_eatjump2()
        {

        }

        public virtual void anm_eatlanding()
        {

        }

        public virtual void anm_eatturn()
        {

        }

        public virtual void anm_eatwait()
        {

        }

        public virtual void anm_eatwalkfast()
        {

        }

        public virtual void anm_eatwalkmiddle()
        {

        }

        public virtual void anm_eatwalkslow()
        {

        }

        public virtual void anm_specialndrink()
        {

        }

        public virtual void anm_specialnegg()
        {

        }

        public virtual void anm_specialairsmax()
        {

        }

        public virtual void anm_specialsfall()
        {

        }

        public virtual void anm_specialsholdmax()
        {

        }

        public virtual void anm_specialsjumpsquat()
        {

        }

        public virtual void anm_specialsmax()
        {

        }

        public virtual void anm_specialsturn()
        {

        }

        public virtual void anm_specialairnbigbitten()
        {

        }

        public virtual void anm_specialairnbigbittenend()
        {

        }

        public virtual void anm_specialairnbigbittenstart()
        {

        }

        public virtual void anm_specialairnbitten()
        {

        }

        public virtual void anm_specialairnbittenend()
        {

        }

        public virtual void anm_specialairnbittenstart()
        {

        }

        public virtual void anm_specialairndxbitten()
        {

        }

        public virtual void anm_specialairndxbittenend()
        {

        }

        public virtual void anm_specialairndxbittenstart()
        {

        }

        public virtual void anm_specialairngirlbitten()
        {

        }

        public virtual void anm_specialairngirlbittenend()
        {

        }

        public virtual void anm_specialairngirlbittenstart()
        {

        }

        public virtual void anm_specialnbigbitten()
        {

        }

        public virtual void anm_specialnbigbittenend()
        {

        }

        public virtual void anm_specialnbigbittenstart()
        {

        }

        public virtual void anm_specialnbitten()
        {

        }

        public virtual void anm_specialnbittenend()
        {

        }

        public virtual void anm_specialnbittenstart()
        {

        }

        public virtual void anm_specialndxbitten()
        {

        }

        public virtual void anm_specialndxbittenend()
        {

        }

        public virtual void anm_specialndxbittenstart()
        {

        }

        public virtual void anm_specialngirlbitten()
        {

        }

        public virtual void anm_specialngirlbittenend()
        {

        }

        public virtual void anm_specialngirlbittenstart()
        {

        }

        public virtual void anm_itemlegsbrakeb()
        {

        }

        public virtual void anm_itemlegsbrakef()
        {

        }

        public virtual void anm_itemlegsdashb()
        {

        }

        public virtual void anm_itemlegsdashf()
        {

        }

        public virtual void anm_itemlegsfastb()
        {

        }

        public virtual void anm_itemlegsfastf()
        {

        }

        public virtual void anm_itemlegsmiddleb()
        {

        }

        public virtual void anm_itemlegsmiddlef()
        {

        }

        public virtual void anm_itemlegsslowb()
        {

        }

        public virtual void anm_itemlegsslowf()
        {

        }

        public virtual void anm_itemlegswait()
        {

        }

        public virtual void anm_adventurerun()
        {

        }

        public virtual void anm_specialairssquat()
        {

        }

        public virtual void anm_specialsaircatch()
        {

        }

        public virtual void anm_specialscatch()
        {

        }

        public virtual void anm_specialssquat()
        {

        }

        public virtual void anm_specialsdxzitabata()
        {

        }

        public virtual void anm_specialsgirlzitabata()
        {

        }

        public virtual void anm_specialszitabata()
        {

        }

        public virtual void anm_death()
        {

        }

        public virtual void anm_deathair()
        {

        }

        public virtual void anm_appealhi()
        {

        }

        public virtual void anm_appeallw()
        {

        }

        public virtual void anm_appeals()
        {

        }

        public virtual void anm_itemhandgrip2()
        {

        }

        public virtual void anm_walkbrake()
        {

        }

        public virtual void anm_specialairsspin()
        {

        }

        public virtual void anm_specialairswallclash()
        {

        }

        public virtual void anm_specialscliffjump()
        {

        }

        public virtual void anm_specialsspin()
        {

        }

        public virtual void anm_specialswallclash()
        {

        }

        public virtual void anm_specialhiattacklanding()
        {

        }

        public virtual void anm_specialhidamageend()
        {

        }

        public virtual void anm_specialhijrattack()
        {

        }

        public virtual void anm_specialhijrdamage()
        {

        }

        public virtual void anm_specialhijrescape()
        {

        }

        public virtual void anm_specialhijrfall()
        {

        }

        public virtual void anm_specialhijrrise()
        {

        }

        public virtual void anm_cliffcatchjr()
        {

        }

        public virtual void anm_cliffwaitjr()
        {

        }

        public virtual void anm_cliffattackjr()
        {

        }

        public virtual void anm_cliffclimbjr()
        {

        }

        public virtual void anm_cliffescapejr()
        {

        }

        public virtual void anm_cliffjump1jr()
        {

        }

        public virtual void anm_specialairnspitb()
        {

        }

        public virtual void anm_specialairnspitf()
        {

        }

        public virtual void anm_specialairnspithi()
        {

        }

        public virtual void anm_specialairnsuction()
        {

        }

        public virtual void anm_specialnspitb()
        {

        }

        public virtual void anm_specialnspitf()
        {

        }

        public virtual void anm_specialnspithi()
        {

        }

        public virtual void anm_specialnsuction()
        {

        }

        public virtual void anm_specialhiairend()
        {

        }

        public virtual void anm_specialhiairendb()
        {

        }

        public virtual void anm_specialhiairendf()
        {

        }

        public virtual void anm_specialhib()
        {

        }

        public virtual void anm_specialhif()
        {

        }

        public virtual void anm_specialhifallb()
        {

        }

        public virtual void anm_specialhifallf()
        {

        }

        public virtual void anm_attacks4s2()
        {

        }

        public virtual void anm_specialairlwblast()
        {

        }

        public virtual void anm_speciallwblast()
        {

        }

        public virtual void anm_specialairndash()
        {

        }

        public virtual void anm_specialairndashturn()
        {

        }

        public virtual void anm_specialairnmaxdash()
        {

        }

        public virtual void anm_specialairnmaxdashend()
        {

        }

        public virtual void anm_specialairnmaxdashturn()
        {

        }

        public virtual void anm_specialndash()
        {

        }

        public virtual void anm_specialndashturn()
        {

        }

        public virtual void anm_specialnmaxdash()
        {

        }

        public virtual void anm_specialnmaxdashend()
        {

        }

        public virtual void anm_specialnmaxdashturn()
        {

        }

        public virtual void anm_specialairsblow()
        {

        }

        public virtual void anm_specialsblowend()
        {

        }

        public virtual void anm_share_ko()
        {

        }

        public virtual void anm_specialairnmax()
        {

        }

        public virtual void anm_specialnmax()
        {

        }

        public virtual void anm_specialhimove()
        {

        }

        public virtual void anm_specialairappear()
        {

        }

        public virtual void anm_speciallwsplit()
        {

        }

        public virtual void anm_finalairreturn()
        {

        }

        public virtual void anm_finalairreturnl()
        {

        }

        public virtual void anm_finalairstartl()
        {

        }

        public virtual void anm_finalairstartr()
        {

        }

        public virtual void anm_finalstartl()
        {

        }

        public virtual void anm_finalstartr()
        {

        }

        public virtual void anm_specialairhiattackend()
        {

        }

        public virtual void anm_specialairlwhold()
        {

        }

        public virtual void anm_aircatchlanding()
        {

        }

        public virtual void anm_specialairnendhi()
        {

        }

        public virtual void anm_specialairnendlw()
        {

        }

        public virtual void anm_specialnendhi()
        {

        }

        public virtual void anm_specialnendlw()
        {

        }

        public virtual void anm_specialsdischarge()
        {

        }

        public virtual void anm_specialhidrop()
        {

        }

        public virtual void anm_finalairfail()
        {

        }

        public virtual void anm_finalairfaill()
        {

        }

        public virtual void anm_finalairshoot()
        {

        }

        public virtual void anm_finalairshootready()
        {

        }

        public virtual void anm_finalairvacuum()
        {

        }

        public virtual void anm_finalfail()
        {

        }

        public virtual void anm_finalfaill()
        {

        }

        public virtual void anm_finalshoot()
        {

        }

        public virtual void anm_finalshootready()
        {

        }

        public virtual void anm_finalvacuum()
        {

        }

        public virtual void anm_catchattackl()
        {

        }

        public virtual void anm_catchcutl()
        {

        }

        public virtual void anm_catchdashl()
        {

        }

        public virtual void anm_catchl()
        {

        }

        public virtual void anm_catchpulll()
        {

        }

        public virtual void anm_catchturnl()
        {

        }

        public virtual void anm_catchwaitl()
        {

        }

        public virtual void anm_throwbl()
        {

        }

        public virtual void anm_throwfl()
        {

        }

        public virtual void anm_throwhil()
        {

        }

        public virtual void anm_throwlwl()
        {

        }

        public virtual void anm_aircatchl()
        {

        }

        public virtual void anm_aircatchlandingl()
        {

        }

        public virtual void anm_specialairlwheavy()
        {

        }

        public virtual void anm_specialairlwlight()
        {

        }

        public virtual void anm_speciallwheavy()
        {

        }

        public virtual void anm_speciallwlight()
        {

        }

        public virtual void anm_specialairsf()
        {

        }

        public virtual void anm_specialairhifailure()
        {

        }

        public virtual void anm_specialairhihit()
        {

        }

        public virtual void anm_specialairhihitpose()
        {

        }

        public virtual void anm_specialairhiovertake()
        {

        }

        public virtual void anm_specialairhiwallfailure()
        {

        }

        public virtual void anm_specialairhiwalljump()
        {

        }

        public virtual void anm_specialhihitpose()
        {

        }

        public virtual void anm_speciallwlanding1()
        {

        }

        public virtual void anm_speciallwlanding2()
        {

        }

        public virtual void anm_aircatchhang2()
        {

        }

        public virtual void anm_share_damage()
        {

        }

        public virtual void anm_runbrake()
        {

        }

        public virtual void anm_attacks3s2()
        {

        }

        public virtual void anm_attacks3s3()
        {

        }

        public virtual void anm_specialnspin()
        {

        }

        public virtual void anm_specialairsfinish()
        {

        }

        public virtual void anm_specialsdrill()
        {

        }

        public virtual void anm_specialairlwb()
        {

        }

        public virtual void anm_specialairlwf()
        {

        }

        public virtual void anm_speciallwb()
        {

        }

        public virtual void anm_speciallwf()
        {

        }

        public virtual void anm_finalfinish()
        {

        }

        public virtual void anm_finalfinishl()
        {

        }

        public virtual void anm_finalfinishr()
        {

        }

        public virtual void anm_finaljump()
        {

        }

        public virtual void anm_finalsquatl()
        {

        }

        public virtual void anm_finalsquatr()
        {

        }

        public virtual void anm_fear()
        {

        }

        public virtual void anm_feardonkey()
        {

        }

        public virtual void anm_feardonkeyreverse()
        {

        }

        public virtual void anm_feardx()
        {

        }

        public virtual void anm_feardxreverse()
        {

        }

        public virtual void anm_feargirl()
        {

        }

        public virtual void anm_feargirlreverse()
        {

        }

        public virtual void anm_fearreverse()
        {

        }

        public virtual void anm_wingfold()
        {

        }

        public virtual void anm_wingloop()
        {

        }

        public virtual void anm_specialairn2finish()
        {

        }

        public virtual void anm_specialairn2finishmiss()
        {

        }

        public virtual void anm_specialairn2miss()
        {

        }

        public virtual void anm_specialairn2start()
        {

        }

        public virtual void anm_specialairn3turn()
        {

        }

        public virtual void anm_specialn2finish()
        {

        }

        public virtual void anm_specialn2finishmiss()
        {

        }

        public virtual void anm_specialn2miss()
        {

        }

        public virtual void anm_specialn2start()
        {

        }

        public virtual void anm_specialn3turn()
        {

        }

        public virtual void anm_specialairs1start()
        {

        }

        public virtual void anm_specialairs2end()
        {

        }

        public virtual void anm_specialairs2start()
        {

        }

        public virtual void anm_specialairs3catch()
        {

        }

        public virtual void anm_specialairs3dash()
        {

        }

        public virtual void anm_specialairs3fall()
        {

        }

        public virtual void anm_specialairs3landing()
        {

        }

        public virtual void anm_specials1start()
        {

        }

        public virtual void anm_specials2end()
        {

        }

        public virtual void anm_specials2hit()
        {

        }

        public virtual void anm_specials2hitlanding()
        {

        }

        public virtual void anm_specials2start()
        {

        }

        public virtual void anm_specials3dash()
        {

        }

        public virtual void anm_specials3throw()
        {

        }

        public virtual void anm_specialairhi11()
        {

        }

        public virtual void anm_specialairhi12()
        {

        }

        public virtual void anm_specialairhi13()
        {

        }

        public virtual void anm_specialhi11()
        {

        }

        public virtual void anm_specialhi14()
        {

        }

        public virtual void anm_specialairlw2autoattack()
        {

        }

        public virtual void anm_specialairlw2kick()
        {

        }

        public virtual void anm_specialairlw2start()
        {

        }

        public virtual void anm_specialairlw3()
        {

        }

        public virtual void anm_specialairlw3catch()
        {

        }

        public virtual void anm_specialairlw3throw()
        {

        }

        public virtual void anm_speciallw1landing()
        {

        }

        public virtual void anm_speciallw1loop()
        {

        }

        public virtual void anm_speciallw2kicklanding()
        {

        }

        public virtual void anm_speciallw2landing()
        {

        }

        public virtual void anm_speciallw2start()
        {

        }

        public virtual void anm_speciallw3()
        {

        }

        public virtual void anm_speciallw3catch()
        {

        }

        public virtual void anm_speciallw3throw()
        {

        }

        public virtual void anm_specialairs3captured()
        {

        }

        public virtual void anm_specialairs3capturedbig()
        {

        }

        public virtual void anm_specialairs3captureddx()
        {

        }

        public virtual void anm_specialairs3capturedgirl()
        {

        }

        public virtual void anm_specialairs3fallbig()
        {

        }

        public virtual void anm_specialairs3falldx()
        {

        }

        public virtual void anm_specialairs3fallgirl()
        {

        }

        public virtual void anm_specialairs3landingbig()
        {

        }

        public virtual void anm_specialairs3landingdx()
        {

        }

        public virtual void anm_specialairs3landinggirl()
        {

        }

        public virtual void anm_specials3thrown()
        {

        }

        public virtual void anm_specials3thrownbig()
        {

        }

        public virtual void anm_specials3throwndx()
        {

        }

        public virtual void anm_specials3throwngirl()
        {

        }

        public virtual void anm_speciallw3thrown()
        {

        }

        public virtual void anm_speciallw3thrownbig()
        {

        }

        public virtual void anm_speciallw3throwndx()
        {

        }

        public virtual void anm_speciallw3throwngirl()
        {

        }

        public virtual void anm_menupose()
        {

        }

        public virtual void anm_menupose2()
        {

        }

        public virtual void anm_specialairn1cancel()
        {

        }

        public virtual void anm_specialairn1hold()
        {

        }

        public virtual void anm_specialairn1jumpcancel()
        {

        }

        public virtual void anm_specialairn1start()
        {

        }

        public virtual void anm_specialairn2end()
        {

        }

        public virtual void anm_specialairn2loop()
        {

        }

        public virtual void anm_specialairn3end()
        {

        }

        public virtual void anm_specialairn3start()
        {

        }

        public virtual void anm_specialn1cancel()
        {

        }

        public virtual void anm_specialn1hold()
        {

        }

        public virtual void anm_specialn1start()
        {

        }

        public virtual void anm_specialn2end()
        {

        }

        public virtual void anm_specialn2loop()
        {

        }

        public virtual void anm_specialn3end()
        {

        }

        public virtual void anm_specialn3start()
        {

        }

        public virtual void anm_specialairs2loop()
        {

        }

        public virtual void anm_specialairs31()
        {

        }

        public virtual void anm_specials2loop()
        {

        }

        public virtual void anm_specials31()
        {

        }

        public virtual void anm_specialairhi2squat()
        {

        }

        public virtual void anm_specialairhi3end()
        {

        }

        public virtual void anm_specialairhi3start()
        {

        }

        public virtual void anm_specialhi2squat()
        {

        }

        public virtual void anm_specialhi3b()
        {

        }

        public virtual void anm_specialhi3f()
        {

        }

        public virtual void anm_specialhi3start()
        {

        }

        public virtual void anm_specialairlw1end()
        {

        }

        public virtual void anm_specialairlw1endl()
        {

        }

        public virtual void anm_specialairlw1hit()
        {

        }

        public virtual void anm_specialairlw1hitl()
        {

        }

        public virtual void anm_specialairlw1loop()
        {

        }

        public virtual void anm_specialairlw1loopl()
        {

        }

        public virtual void anm_specialairlw1start()
        {

        }

        public virtual void anm_specialairlw1startl()
        {

        }

        public virtual void anm_specialairlw3end()
        {

        }

        public virtual void anm_specialairlw3hit()
        {

        }

        public virtual void anm_specialairlw3hold()
        {

        }

        public virtual void anm_specialairlw3start()
        {

        }

        public virtual void anm_speciallw1end()
        {

        }

        public virtual void anm_speciallw1endl()
        {

        }

        public virtual void anm_speciallw1hit()
        {

        }

        public virtual void anm_speciallw1hitl()
        {

        }

        public virtual void anm_speciallw1loopl()
        {

        }

        public virtual void anm_speciallw1start()
        {

        }

        public virtual void anm_speciallw1startl()
        {

        }

        public virtual void anm_speciallw3end()
        {

        }

        public virtual void anm_speciallw3hit()
        {

        }

        public virtual void anm_speciallw3hold()
        {

        }

        public virtual void anm_speciallw3start()
        {

        }

        public virtual void anm_finalaird()
        {

        }

        public virtual void anm_finalairu()
        {

        }

        public virtual void anm_finald()
        {

        }

        public virtual void anm_finalu()
        {

        }

        public virtual void anm_specialairn3endturn()
        {

        }

        public virtual void anm_specialairn3loop()
        {

        }

        public virtual void anm_specialn3endturn()
        {

        }

        public virtual void anm_specialn3loop()
        {

        }

        public virtual void anm_specialairs1end()
        {

        }

        public virtual void anm_specialairs2attack()
        {

        }

        public virtual void anm_specialairs2dash()
        {

        }

        public virtual void anm_specialairs2hold()
        {

        }

        public virtual void anm_specialairs31hi()
        {

        }

        public virtual void anm_specialairs31lw()
        {

        }

        public virtual void anm_specials1end()
        {

        }

        public virtual void anm_specials1hit()
        {

        }

        public virtual void anm_specials2attack()
        {

        }

        public virtual void anm_specials2dash()
        {

        }

        public virtual void anm_specials2hold()
        {

        }

        public virtual void anm_specials31hi()
        {

        }

        public virtual void anm_specials31lw()
        {

        }

        public virtual void anm_specialairhi1loop()
        {

        }

        public virtual void anm_specialairhi1start()
        {

        }

        public virtual void anm_specialhi1end()
        {

        }

        public virtual void anm_specialhi1start()
        {

        }

        public virtual void anm_specialhi2bound()
        {

        }

        public virtual void anm_specialhi2fall()
        {

        }

        public virtual void anm_specialhi2hold()
        {

        }

        public virtual void anm_specialhi2holdair()
        {

        }

        public virtual void anm_specialhi2landing()
        {

        }

        public virtual void anm_specialhi3hold()
        {

        }

        public virtual void anm_specialairlw3endair()
        {

        }

        public virtual void anm_speciallw3endair()
        {

        }

        public virtual void anm_attack11end()
        {

        }

        public virtual void anm_attack12end()
        {

        }

        public virtual void anm_specialairnfailure()
        {

        }

        public virtual void anm_specialairnhand()
        {

        }

        public virtual void anm_specialairntake()
        {

        }

        public virtual void anm_specialairnuse()
        {

        }

        public virtual void anm_specialairnuse2()
        {

        }

        public virtual void anm_specialnfailure()
        {

        }

        public virtual void anm_specialnhand()
        {

        }

        public virtual void anm_specialntake()
        {

        }

        public virtual void anm_specialnuse()
        {

        }

        public virtual void anm_specialnuse2()
        {

        }

        public virtual void anm_specialairsride()
        {

        }

        public virtual void anm_specialairsrideloop()
        {

        }

        public virtual void anm_specialsride()
        {

        }

        public virtual void anm_specialsrideloop()
        {

        }

        public virtual void anm_specialairhidetach()
        {

        }

        public virtual void anm_specialairhiflap2()
        {

        }

        public virtual void anm_specialairhilanding2()
        {

        }

        public virtual void anm_specialairhiwait2()
        {

        }

        public virtual void anm_specialairlw1failure()
        {

        }

        public virtual void anm_speciallw1failure()
        {

        }

        public virtual void anm_speciallw2legsdashb()
        {

        }

        public virtual void anm_speciallw2legsdashf()
        {

        }

        public virtual void anm_finalaircheerr()
        {

        }

        public virtual void anm_finalairhappyr()
        {

        }

        public virtual void anm_finalairmoneyr()
        {

        }

        public virtual void anm_finalairr()
        {

        }

        public virtual void anm_finalairsurpriser()
        {

        }

        public virtual void anm_finalcheerr()
        {

        }

        public virtual void anm_finalhappyr()
        {

        }

        public virtual void anm_finalmoneyr()
        {

        }

        public virtual void anm_finalr()
        {

        }

        public virtual void anm_finalsurpriser()
        {

        }

        public virtual void anm_itemhandhavel()
        {

        }

        public virtual void anm_turnl()
        {

        }

        public virtual void anm_turndashl()
        {

        }

        public virtual void anm_turnrunbrakel()
        {

        }

        public virtual void anm_turnrunl()
        {

        }

        public virtual void anm_escapefl()
        {

        }

        public virtual void anm_specialairs2nana()
        {

        }

        public virtual void anm_specials2nana()
        {

        }

        public virtual void anm_specialairhistartnana()
        {

        }

        public virtual void anm_specialairhithrow2()
        {

        }

        public virtual void anm_specialhistartnana()
        {

        }

        public virtual void anm_specialhithrow2()
        {

        }

        public virtual void anm_specialhithrow2nana()
        {

        }

        public virtual void anm_specialhithrownana()
        {

        }

        public virtual void anm_final1r()
        {

        }

        public virtual void anm_final2nana()
        {

        }

        public virtual void anm_finalair1r()
        {

        }

        public virtual void anm_finalair2nana()
        {

        }

        public virtual void anm_finalhang()
        {

        }

        public virtual void anm_finalhangnana()
        {

        }

        public virtual void anm_throwbnana()
        {

        }

        public virtual void anm_throwfnana()
        {

        }

        public virtual void anm_throwhinana()
        {

        }

        public virtual void anm_throwlwnana()
        {

        }

        public virtual void anm_capturepanicnana()
        {

        }

        public virtual void anm_entryrnana()
        {

        }

        public virtual void anm_losenana()
        {

        }

        public virtual void anm_win1nana()
        {

        }

        public virtual void anm_win1waitnana()
        {

        }

        public virtual void anm_win2nana()
        {

        }

        public virtual void anm_win2waitnana()
        {

        }

        public virtual void anm_win3nana()
        {

        }

        public virtual void anm_win3waitnana()
        {

        }

        public virtual void anm_capture2facial()
        {

        }

        public virtual void anm_capture3facial()
        {

        }

        public virtual void anm_capture4facial()
        {

        }

        public virtual void anm_capturefacial()
        {

        }

        public virtual void anm_specialnairfire()
        {

        }

        public virtual void anm_defaulttemporarily()
        {

        }

        public virtual void anm_squatsteppose()
        {

        }

        public virtual void anm_squatstepposeback()
        {

        }

        public virtual void anm_attack100end()
        {
            GroundAttack();
        }

        public virtual void anm_attck100start()
        {

        }

        public virtual void anm_specialairnshootb()
        {

        }

        public virtual void anm_specialairnshootf()
        {

        }

        public virtual void anm_specialairnwait()
        {

        }

        public virtual void anm_specialnshootb()
        {

        }

        public virtual void anm_specialnshootf()
        {

        }

        public virtual void anm_specialairscancel()
        {

        }

        public virtual void anm_specialairscharge()
        {

        }

        public virtual void anm_specialairsjumpcancel()
        {

        }

        public virtual void anm_specialairsshoot()
        {

        }

        public virtual void anm_specialscancel()
        {

        }

        public virtual void anm_specialscharge()
        {

        }

        public virtual void anm_specialsshoot()
        {

        }

        public virtual void anm_specialairhiclownfall()
        {

        }

        public virtual void anm_specialhicliffcatch()
        {

        }

        public virtual void anm_specialhiclownfall()
        {

        }

        public virtual void anm_specialairlwbite()
        {

        }

        public virtual void anm_specialairlwcharge()
        {

        }

        public virtual void anm_specialairlwfallb()
        {

        }

        public virtual void anm_specialairlwfallend()
        {

        }

        public virtual void anm_specialairlwfallf()
        {

        }

        public virtual void anm_speciallwbite()
        {

        }

        public virtual void anm_speciallwcharge()
        {

        }

        public virtual void anm_speciallwfallb()
        {

        }

        public virtual void anm_speciallwfallend()
        {

        }

        public virtual void anm_speciallwfallf()
        {

        }

        public virtual void anm_specialairsloop()
        {

        }

        public virtual void anm_specialairsreturn()
        {

        }

        public virtual void anm_specialschange()
        {

        }

        public virtual void anm_specialsloop()
        {

        }

        public virtual void anm_specialsmove()
        {

        }

        public virtual void anm_specialsreturn()
        {

        }

        public virtual void anm_specialairlwfailure()
        {

        }

        public virtual void anm_speciallwfailure()
        {

        }

        public virtual void anm_capturedamagepacmanzitabata()
        {

        }

        public virtual void anm_capturepacmanzitabata()
        {

        }

        public virtual void anm_capturepulledpacmanzitabata()
        {

        }

        public virtual void anm_gost()
        {

        }

        public virtual void anm_ijike()
        {

        }

        public virtual void anm_specialairlwattackl()
        {

        }

        public virtual void anm_specialairlwattackr()
        {

        }

        public virtual void anm_specialairlwl()
        {

        }

        public virtual void anm_specialairlwreflect()
        {

        }

        public virtual void anm_speciallwattackl()
        {

        }

        public virtual void anm_speciallwattackr()
        {

        }

        public virtual void anm_speciallwl()
        {

        }

        public virtual void anm_speciallwreflect()
        {

        }

        public virtual void anm_finalairbeam()
        {

        }

        public virtual void anm_finalairbeamendr()
        {

        }

        public virtual void anm_finalairbeamstart()
        {

        }

        public virtual void anm_finalbeam()
        {

        }

        public virtual void anm_finalbeamendr()
        {

        }

        public virtual void anm_finalbeamstart()
        {

        }

        public virtual void anm_specialairlwin()
        {

        }

        public virtual void anm_specialairlwout()
        {

        }

        public virtual void anm_speciallwin()
        {

        }

        public virtual void anm_speciallwout()
        {

        }

        public virtual void anm_catchattackm()
        {

        }

        public virtual void anm_catchwaitm()
        {

        }

        public virtual void anm_snakethrownlw()
        {

        }

        public virtual void anm_respawn()
        {

        }

        public virtual void anm_specialairsmissend()
        {

        }

        public virtual void anm_specialairsready()
        {

        }

        public virtual void anm_specialsready()
        {

        }

        public virtual void anm_specialairhilanding1()
        {

        }

        public virtual void anm_specialairhiwait1()
        {

        }

        public virtual void anm_specialairnfirehi()
        {

        }

        public virtual void anm_specialairnfires()
        {

        }

        public virtual void anm_specialairnhitos()
        {

        }

        public virtual void anm_specialairnholdhi()
        {

        }

        public virtual void anm_specialairnholds()
        {

        }

        public virtual void anm_specialairnstohi()
        {

        }

        public virtual void anm_specialairnstos()
        {

        }

        public virtual void anm_specialnfirehi()
        {

        }

        public virtual void anm_specialnfires()
        {

        }

        public virtual void anm_specialnhitos()
        {

        }

        public virtual void anm_specialnholdhi()
        {

        }

        public virtual void anm_specialnholds()
        {

        }

        public virtual void anm_specialnstohi()
        {

        }

        public virtual void anm_specialnstos()
        {

        }

        public virtual void anm_specialairlwendr()
        {

        }

        public virtual void anm_specialairlwstartr()
        {

        }

        public virtual void anm_speciallwendr()
        {

        }

        public virtual void anm_speciallwstartr()
        {

        }

        public virtual void anm_finalride()
        {

        }

        public virtual void anm_specialairsblown()
        {

        }

        public virtual void anm_specialsblown()
        {

        }

        public virtual void anm_specialairnendr()
        {

        }

        public virtual void anm_specialairnstartr()
        {

        }

        public virtual void anm_specialnendr()
        {

        }

        public virtual void anm_specialnstartr()
        {

        }

        public virtual void anm_specialairhir()
        {

        }

        public virtual void anm_specialhir()
        {

        }

        public virtual void anm_specialairshit()
        {

        }

        public virtual void anm_specialsoverturn()
        {

        }

        public virtual void anm_specialsoverturnstart()
        {

        }

        public virtual void anm_win3g_us_en()
        {

        }

        public virtual void anm_attackhi42()
        {

        }

        public virtual void anm_specialairntronend()
        {

        }

        public virtual void anm_specialairntronhold()
        {

        }

        public virtual void anm_specialairntronstart()
        {

        }

        public virtual void anm_specialntronend()
        {

        }

        public virtual void anm_specialntronhold()
        {

        }

        public virtual void anm_specialntronstart()
        {

        }

        public virtual void anm_specialairhifail()
        {

        }

        public virtual void anm_specialairlwcapture()
        {

        }

        public virtual void anm_speciallwcapture()
        {

        }

        public virtual void anm_nobookhand()
        {

        }

        public virtual void anm_resurrectionbook()
        {

        }

        public virtual void anm_resurrectionthundersword()
        {

        }

        public virtual void anm_book()
        {

        }

        public virtual void anm_thunderswordm()
        {

        }

        public virtual void anm_attackairhold()
        {

        }

        public virtual void anm_attackairholdend()
        {

        }

        public virtual void anm_attackairholdstart()
        {

        }

        public virtual void anm_attackairholdstarts3()
        {

        }

        public virtual void anm_attackhold()
        {

        }

        public virtual void anm_attackholdend()
        {

        }

        public virtual void anm_attackholdstart()
        {

        }

        public virtual void anm_attackholdstarts3()
        {

        }

        public virtual void anm_attacklw32()
        {

        }

        public virtual void anm_attacklw32landing()
        {

        }

        public virtual void anm_attackairbhi()
        {

        }

        public virtual void anm_attackairblw()
        {

        }

        public virtual void anm_attackairfhi()
        {

        }

        public virtual void anm_attackairflw()
        {

        }

        public virtual void anm_attackairlw2()
        {

        }

        public virtual void anm_landingairlw2()
        {

        }

        public virtual void anm_specialairscut()
        {

        }

        public virtual void anm_specialairsdragjump()
        {

        }

        public virtual void anm_specialsdrag()
        {

        }

        public virtual void anm_specialsdragcliff()
        {

        }

        public virtual void anm_specialsdragf()
        {

        }

        public virtual void anm_specialsdragwall()
        {

        }

        public virtual void anm_specialairhiceil()
        {

        }

        public virtual void anm_specialairhichargeendb()
        {

        }

        public virtual void anm_specialairhichargeendf()
        {

        }

        public virtual void anm_specialairhichargeendhi()
        {

        }

        public virtual void anm_specialairhichargeendlw()
        {

        }

        public virtual void anm_specialairhichargehi()
        {

        }

        public virtual void anm_specialairhichargelw()
        {

        }

        public virtual void anm_specialairhichargestartb()
        {

        }

        public virtual void anm_specialairhichargestartf()
        {

        }

        public virtual void anm_specialairhichargestarthi()
        {

        }

        public virtual void anm_specialairhichargestartlw()
        {

        }

        public virtual void anm_specialairhihover()
        {

        }

        public virtual void anm_specialairhiwallb()
        {

        }

        public virtual void anm_specialairhiwallf()
        {

        }

        public virtual void anm_specialhilandingf()
        {

        }

        public virtual void anm_specialhilandinglw()
        {

        }

        public virtual void anm_specialairlwfinish()
        {

        }

        public virtual void anm_specialairlwstab()
        {

        }

        public virtual void anm_speciallwfinish()
        {

        }

        public virtual void anm_speciallwstab()
        {

        }

        public virtual void anm_speciallwstabbed()
        {

        }

        public virtual void anm_speciallwstabbedbig()
        {

        }

        public virtual void anm_speciallwstabbeddx()
        {

        }

        public virtual void anm_speciallwstabbedgirl()
        {

        }

        public virtual void anm_speciallwstabbedsmall()
        {

        }

        public virtual void anm_finaldashloop()
        {

        }

        public virtual void anm_specialscaught()
        {

        }

        public virtual void anm_specialscaughtbig()
        {

        }

        public virtual void anm_specialscaughtdx()
        {

        }

        public virtual void anm_specialscaughtgirl()
        {

        }

        public virtual void anm_specialsdragged()
        {

        }

        public virtual void anm_specialsdraggedbig()
        {

        }

        public virtual void anm_specialsdraggedcliff()
        {

        }

        public virtual void anm_specialsdraggedcliffbig()
        {

        }

        public virtual void anm_specialsdraggedcliffdx()
        {

        }

        public virtual void anm_specialsdraggedcliffgirl()
        {

        }

        public virtual void anm_specialsdraggeddx()
        {

        }

        public virtual void anm_specialsdraggedf()
        {

        }

        public virtual void anm_specialsdraggedfbig()
        {

        }

        public virtual void anm_specialsdraggedfdx()
        {

        }

        public virtual void anm_specialsdraggedfgirl()
        {

        }

        public virtual void anm_specialsdraggedgirl()
        {

        }

        public virtual void anm_specialsdraggedwall()
        {

        }

        public virtual void anm_specialsdraggedwallbig()
        {

        }

        public virtual void anm_specialsdraggedwalldx()
        {

        }

        public virtual void anm_specialsdraggedwallgirl()
        {

        }

        public virtual void anm_specialhirise()
        {

        }

        public virtual void anm_empty()
        {

        }

        public virtual void anm_indicator()
        {

        }

        public virtual void anm_attack1()
        {

        }

        public virtual void anm_attack1end()
        {

        }

        public virtual void anm_attack1start()
        {

        }

        public virtual void anm_attack1turn()
        {

        }

        public virtual void anm_attacks3end()
        {

        }

        public virtual void anm_attacks3fast()
        {

        }

        public virtual void anm_attacks3middle()
        {

        }

        public virtual void anm_attacks3slow()
        {

        }

        public virtual void anm_attacks3start()
        {

        }

        public virtual void anm_attackairnend()
        {

        }

        public virtual void anm_attackairnstart()
        {

        }

        public virtual void anm_specialairnturnempty()
        {

        }

        public virtual void anm_specialnturnempty()
        {

        }

        public virtual void anm_specialhisquat()
        {

        }

        public virtual void anm_capturedamagedxzitabata()
        {

        }

        public virtual void anm_capturedamagegirlzitabata()
        {

        }

        public virtual void anm_capturedamagezitabata()
        {

        }

        public virtual void anm_capturedxzitabata()
        {

        }

        public virtual void anm_capturegirlzitabata()
        {

        }

        public virtual void anm_capturepulleddxzitabata()
        {

        }

        public virtual void anm_capturepulledgirlzitabata()
        {

        }

        public virtual void anm_capturepulledzitabata()
        {

        }

        public virtual void anm_capturezitabata()
        {

        }

        public virtual void anm_specialairnchargestart()
        {

        }

        public virtual void anm_specialairnreturn()
        {

        }

        public virtual void anm_specialnchargestart()
        {

        }

        public virtual void anm_specialnreturn()
        {

        }

        public virtual void anm_finalairhitend()
        {

        }

        public virtual void anm_finalhitfall()
        {

        }

        public virtual void anm_finalhitlanding()
        {

        }

        public virtual void anm_finaldamage01()
        {

        }

        public virtual void anm_finaldamage02()
        {

        }

        public virtual void anm_finaldamage03()
        {

        }

        public virtual void anm_special()
        {

        }

        public virtual void anm_specialair()
        {

        }

        public virtual void anm_eye()
        {

        }

        public virtual void anm_specialairsfire()
        {

        }

        public virtual void anm_specialsfire()
        {

        }

        public virtual void anm_speciallwattacklanding()
        {

        }

        public virtual void anm_speciallwreturn()
        {

        }

        public virtual void anm_speciallwreturnlanding()
        {

        }

        public virtual void anm_specialairscatchwait()
        {

        }

        public virtual void anm_specialairshitreel()
        {

        }

        public virtual void anm_specialairsitem()
        {

        }

        public virtual void anm_specialairsreel()
        {

        }

        public virtual void anm_specialairsreelhi()
        {

        }

        public virtual void anm_specialairsreellw()
        {

        }

        public virtual void anm_specialairsthrowb()
        {

        }

        public virtual void anm_specialairsthrowf()
        {

        }

        public virtual void anm_specialairsthrowhi()
        {

        }

        public virtual void anm_specialairsthrowlw()
        {

        }

        public virtual void anm_specialscatchwait()
        {

        }

        public virtual void anm_specialscut()
        {

        }

        public virtual void anm_specialshit()
        {

        }

        public virtual void anm_specialshitreel()
        {

        }

        public virtual void anm_specialsitem()
        {

        }

        public virtual void anm_specialsreel()
        {

        }

        public virtual void anm_specialsreelhi()
        {

        }

        public virtual void anm_specialsreellw()
        {

        }

        public virtual void anm_specialsthrowb()
        {

        }

        public virtual void anm_specialsthrowf()
        {

        }

        public virtual void anm_specialsthrowhi()
        {

        }

        public virtual void anm_specialsthrowlw()
        {

        }

        public virtual void anm_specialairlwfire()
        {

        }

        public virtual void anm_speciallwfire()
        {

        }

        public virtual void anm_speciallwset()
        {

        }

        public virtual void anm_specialsthrownb()
        {

        }

        public virtual void anm_specialsthrownbigb()
        {

        }

        public virtual void anm_specialsthrownbigf()
        {

        }

        public virtual void anm_specialsthrownbighi()
        {

        }

        public virtual void anm_specialsthrownbiglw()
        {

        }

        public virtual void anm_specialsthrowndxb()
        {

        }

        public virtual void anm_specialsthrowndxf()
        {

        }

        public virtual void anm_specialsthrowndxhi()
        {

        }

        public virtual void anm_specialsthrowndxlw()
        {

        }

        public virtual void anm_specialsthrownf()
        {

        }

        public virtual void anm_specialsthrowngirlb()
        {

        }

        public virtual void anm_specialsthrowngirlf()
        {

        }

        public virtual void anm_specialsthrowngirlhi()
        {

        }

        public virtual void anm_specialsthrowngirllw()
        {

        }

        public virtual void anm_specialsthrownhi()
        {

        }

        public virtual void anm_specialsthrownlw()
        {

        }

        public virtual void anm_specialairnbuster()
        {

        }

        public virtual void anm_specialairnjump()
        {

        }

        public virtual void anm_specialairnshield()
        {

        }

        public virtual void anm_specialairnsmash()
        {

        }

        public virtual void anm_specialairnspeed()
        {

        }

        public virtual void anm_specialnbuster()
        {

        }

        public virtual void anm_specialnshield()
        {

        }

        public virtual void anm_specialnsmash()
        {

        }

        public virtual void anm_specialnspeed()
        {

        }

        public virtual void anm_specialhiadd()
        {

        }

        public virtual void anm_specialairlwn()
        {

        }

        public virtual void anm_finalvisualsceneattack()
        {

        }

        public virtual void anm_finalvisualsceneentry()
        {

        }

        public virtual void anm_specialairnthrowhi()
        {

        }

        public virtual void anm_specialairnthrowlw()
        {

        }

        public virtual void anm_specialairnthrowm()
        {

        }

        public virtual void anm_specialnclose()
        {

        }

        public virtual void anm_specialnlegsdashb()
        {

        }

        public virtual void anm_specialnlegsdashf()
        {

        }

        public virtual void anm_specialnthrowhi()
        {

        }

        public virtual void anm_specialnthrowlw()
        {

        }

        public virtual void anm_specialnthrowm()
        {

        }

        public virtual void anm_specialairsaway()
        {

        }

        public virtual void anm_specialairsoperation()
        {

        }

        public virtual void anm_specialsaway()
        {

        }

        public virtual void anm_specialsoperation()
        {

        }

        public virtual void anm_specialairhihang()
        {

        }

        public virtual void anm_specialairlwenemy()
        {

        }

        public virtual void anm_specialairlwground()
        {

        }

        public virtual void anm_specialairlwwall()
        {

        }

        public virtual void anm_speciallwenemy()
        {

        }

        public virtual void anm_speciallwground()
        {

        }

        public virtual void anm_speciallwsquatblast()
        {

        }

        public virtual void anm_speciallwsquatground()
        {

        }

        public virtual void anm_speciallwsquatstart()
        {

        }

        public virtual void anm_speciallwwall()
        {

        }

        public virtual void anm_finalairwait()
        {

        }

        public virtual void anm_finalairwaitl()
        {

        }

        public virtual void anm_finalappeal()
        {

        }

        public virtual void anm_finalappeall()
        {

        }

        public virtual void anm_finalwait()
        {

        }

        public virtual void anm_finalwaitl()
        {

        }

        public virtual void anm_capturedamagebigsnake()
        {

        }

        public virtual void anm_capturedamagedxsnake()
        {

        }

        public virtual void anm_capturedamagesnake()
        {

        }

        public virtual void anm_capturepulledbigsnake()
        {

        }

        public virtual void anm_capturepulleddxsnake()
        {

        }

        public virtual void anm_capturepulledsnake()
        {

        }

        public virtual void anm_capturewaitbigsnake()
        {

        }

        public virtual void anm_capturewaitdxsnake()
        {

        }

        public virtual void anm_capturewaitsnake()
        {

        }

        public virtual void anm_appealend()
        {

        }

        public virtual void anm_appealwait()
        {

        }

        public virtual void anm_appealsend()
        {

        }

        public virtual void anm_appealsreceive()
        {

        }

        public virtual void anm_appealsstart()
        {

        }

        public virtual void anm_appealstransmit()
        {

        }

        public virtual void anm_specialnrebound()
        {

        }

        public virtual void anm_specialairsendloop()
        {

        }

        public virtual void anm_specialairsendstart()
        {

        }

        public virtual void anm_specialsdashhi()
        {

        }

        public virtual void anm_specialsdashlw()
        {

        }

        public virtual void anm_specialsendloop()
        {

        }

        public virtual void anm_specialsendstart()
        {

        }

        public virtual void anm_specialairnshooth()
        {

        }

        public virtual void anm_specialnshooth()
        {

        }

        public virtual void anm_specialairlwflip()
        {

        }

        public virtual void anm_specialairlwkick()
        {

        }

        public virtual void anm_specialairlwstep()
        {

        }

        public virtual void anm_speciallwkicklanding()
        {

        }

        public virtual void anm_dragonend()
        {

        }

        public virtual void anm_dragonloop()
        {

        }

        public virtual void anm_dragonstart()
        {

        }

        public virtual void anm_dragonwait()
        {

        }

        public virtual void anm_attackbothend()
        {

        }

        public virtual void anm_attackbothendb()
        {

        }

        public virtual void anm_attackbothendl()
        {

        }

        public virtual void anm_attackbothendr()
        {

        }

        public virtual void anm_attacklegsbothend()
        {

        }

        public virtual void anm_attacklegsbothendb()
        {

        }

        public virtual void anm_attacklegsbothendl()
        {

        }

        public virtual void anm_attacklegsbothendr()
        {

        }

        public virtual void anm_attacklegsfall()
        {

        }

        public virtual void anm_attacklegsfallaerial()
        {

        }

        public virtual void anm_attacklegsjumpaerialb()
        {

        }

        public virtual void anm_attacklegsjumpaerialf()
        {

        }

        public virtual void anm_attacklegsjumpb()
        {

        }

        public virtual void anm_attacklegsjumpf()
        {

        }

        public virtual void anm_attacklegsjumpsquat()
        {

        }

        public virtual void anm_attacklegslandingheavy()
        {

        }

        public virtual void anm_attacklegslandinglight()
        {

        }

        public virtual void anm_attacklegslongendl1()
        {

        }

        public virtual void anm_attacklegslongendlb1()
        {

        }

        public virtual void anm_attacklegslongendlb3()
        {

        }

        public virtual void anm_attacklegslongendr1()
        {

        }

        public virtual void anm_attacklegslongendrb1()
        {

        }

        public virtual void anm_attacklegslongendrb3()
        {

        }

        public virtual void anm_attacklegslongl1()
        {

        }

        public virtual void anm_attacklegslongl2()
        {

        }

        public virtual void anm_attacklegslongl3()
        {

        }

        public virtual void anm_attacklegslonglb1()
        {

        }

        public virtual void anm_attacklegslonglb2()
        {

        }

        public virtual void anm_attacklegslonglb3()
        {

        }

        public virtual void anm_attacklegslongpulll2()
        {

        }

        public virtual void anm_attacklegslongpulll3()
        {

        }

        public virtual void anm_attacklegslongpulllb2()
        {

        }

        public virtual void anm_attacklegslongpulllb3()
        {

        }

        public virtual void anm_attacklegslongpullr2()
        {

        }

        public virtual void anm_attacklegslongpullr3()
        {

        }

        public virtual void anm_attacklegslongpullrb2()
        {

        }

        public virtual void anm_attacklegslongpullrb3()
        {

        }

        public virtual void anm_attacklegslongr1()
        {

        }

        public virtual void anm_attacklegslongr2()
        {

        }

        public virtual void anm_attacklegslongr3()
        {

        }

        public virtual void anm_attacklegslongrb1()
        {

        }

        public virtual void anm_attacklegslongrb2()
        {

        }

        public virtual void anm_attacklegslongrb3()
        {

        }

        public virtual void anm_attacklegslongstartl1()
        {

        }

        public virtual void anm_attacklegslongstartl2()
        {

        }

        public virtual void anm_attacklegslongstartl3()
        {

        }

        public virtual void anm_attacklegslongstartlb1()
        {

        }

        public virtual void anm_attacklegslongstartlb2()
        {

        }

        public virtual void anm_attacklegslongstartlb3()
        {

        }

        public virtual void anm_attacklegslongstartr1()
        {

        }

        public virtual void anm_attacklegslongstartr2()
        {

        }

        public virtual void anm_attacklegslongstartr3()
        {

        }

        public virtual void anm_attacklegslongstartrb1()
        {

        }

        public virtual void anm_attacklegslongstartrb2()
        {

        }

        public virtual void anm_attacklegslongstartrb3()
        {

        }

        public virtual void anm_attacklegss4chargel()
        {

        }

        public virtual void anm_attacklegss4chargelb()
        {

        }

        public virtual void anm_attacklegss4charger()
        {

        }

        public virtual void anm_attacklegss4chargerb()
        {

        }

        public virtual void anm_attacklegsshortendl1()
        {

        }

        public virtual void anm_attacklegsshortendlb1()
        {

        }

        public virtual void anm_attacklegsshortendlb3()
        {

        }

        public virtual void anm_attacklegsshortendr1()
        {

        }

        public virtual void anm_attacklegsshortendrb1()
        {

        }

        public virtual void anm_attacklegsshortendrb3()
        {

        }

        public virtual void anm_attacklegsshortl1()
        {

        }

        public virtual void anm_attacklegsshortl2()
        {

        }

        public virtual void anm_attacklegsshortl3()
        {

        }

        public virtual void anm_attacklegsshortlb1()
        {

        }

        public virtual void anm_attacklegsshortlb2()
        {

        }

        public virtual void anm_attacklegsshortlb3()
        {

        }

        public virtual void anm_attacklegsshortpulll2()
        {

        }

        public virtual void anm_attacklegsshortpulll3()
        {

        }

        public virtual void anm_attacklegsshortpulllb2()
        {

        }

        public virtual void anm_attacklegsshortpulllb3()
        {

        }

        public virtual void anm_attacklegsshortpullr2()
        {

        }

        public virtual void anm_attacklegsshortpullr3()
        {

        }

        public virtual void anm_attacklegsshortpullrb2()
        {

        }

        public virtual void anm_attacklegsshortpullrb3()
        {

        }

        public virtual void anm_attacklegsshortr1()
        {

        }

        public virtual void anm_attacklegsshortr2()
        {

        }

        public virtual void anm_attacklegsshortr3()
        {

        }

        public virtual void anm_attacklegsshortrb1()
        {

        }

        public virtual void anm_attacklegsshortrb2()
        {

        }

        public virtual void anm_attacklegsshortrb3()
        {

        }

        public virtual void anm_attacklegsshortstartl1()
        {

        }

        public virtual void anm_attacklegsshortstartl2()
        {

        }

        public virtual void anm_attacklegsshortstartl3()
        {

        }

        public virtual void anm_attacklegsshortstartlb1()
        {

        }

        public virtual void anm_attacklegsshortstartlb2()
        {

        }

        public virtual void anm_attacklegsshortstartlb3()
        {

        }

        public virtual void anm_attacklegsshortstartr1()
        {

        }

        public virtual void anm_attacklegsshortstartr2()
        {

        }

        public virtual void anm_attacklegsshortstartr3()
        {

        }

        public virtual void anm_attacklegsshortstartrb1()
        {

        }

        public virtual void anm_attacklegsshortstartrb2()
        {

        }

        public virtual void anm_attacklegsshortstartrb3()
        {

        }

        public virtual void anm_attacklegssquat()
        {

        }

        public virtual void anm_attacklegssquatrv()
        {

        }

        public virtual void anm_attacklegssquatwait()
        {

        }

        public virtual void anm_attacklegstwfall()
        {

        }

        public virtual void anm_attacklegstwfallaerial()
        {

        }

        public virtual void anm_attacklegstwjumpaerialb()
        {

        }

        public virtual void anm_attacklegstwjumpaerialf()
        {

        }

        public virtual void anm_attacklegstwjumpb()
        {

        }

        public virtual void anm_attacklegstwjumpf()
        {

        }

        public virtual void anm_attacklegstwjumpsquat()
        {

        }

        public virtual void anm_attacklegstwlandingheavy()
        {

        }

        public virtual void anm_attacklegstwlandinglight()
        {

        }

        public virtual void anm_attacklegstwsquat()
        {

        }

        public virtual void anm_attacklegstwsquatrv()
        {

        }

        public virtual void anm_attacklegstwsquatwait()
        {

        }

        public virtual void anm_attacklegstwwait()
        {

        }

        public virtual void anm_attacklegstwwalkbrakel()
        {

        }

        public virtual void anm_attacklegstwwalkbrakelb()
        {

        }

        public virtual void anm_attacklegstwwalkbraker()
        {

        }

        public virtual void anm_attacklegstwwalkbrakerb()
        {

        }

        public virtual void anm_attacklegstwwalkfast()
        {

        }

        public virtual void anm_attacklegstwwalkfastb()
        {

        }

        public virtual void anm_attacklegstwwalkmiddle()
        {

        }

        public virtual void anm_attacklegstwwalkmiddleb()
        {

        }

        public virtual void anm_attacklegstwwalkslow()
        {

        }

        public virtual void anm_attacklegstwwalkslowb()
        {

        }

        public virtual void anm_attacklegswait()
        {

        }

        public virtual void anm_attacklegswalkbrakel()
        {

        }

        public virtual void anm_attacklegswalkbrakelb()
        {

        }

        public virtual void anm_attacklegswalkbraker()
        {

        }

        public virtual void anm_attacklegswalkbrakerb()
        {

        }

        public virtual void anm_attacklegswalkfast()
        {

        }

        public virtual void anm_attacklegswalkfastb()
        {

        }

        public virtual void anm_attacklegswalkmiddle()
        {

        }

        public virtual void anm_attacklegswalkmiddleb()
        {

        }

        public virtual void anm_attacklegswalkslow()
        {

        }

        public virtual void anm_attacklegswalkslowb()
        {

        }

        public virtual void anm_attacklongendl1()
        {

        }

        public virtual void anm_attacklongendlb1()
        {

        }

        public virtual void anm_attacklongendlb3()
        {

        }

        public virtual void anm_attacklongendr1()
        {

        }

        public virtual void anm_attacklongendrb1()
        {

        }

        public virtual void anm_attacklongendrb3()
        {

        }

        public virtual void anm_attacklongl1()
        {

        }

        public virtual void anm_attacklongl2()
        {

        }

        public virtual void anm_attacklongl3()
        {

        }

        public virtual void anm_attacklonglb1()
        {

        }

        public virtual void anm_attacklonglb2()
        {

        }

        public virtual void anm_attacklonglb3()
        {

        }

        public virtual void anm_attacklongpulll2()
        {

        }

        public virtual void anm_attacklongpulll3()
        {

        }

        public virtual void anm_attacklongpulllb2()
        {

        }

        public virtual void anm_attacklongpulllb3()
        {

        }

        public virtual void anm_attacklongpullr2()
        {

        }

        public virtual void anm_attacklongpullr3()
        {

        }

        public virtual void anm_attacklongpullrb2()
        {

        }

        public virtual void anm_attacklongpullrb3()
        {

        }

        public virtual void anm_attacklongr1()
        {

        }

        public virtual void anm_attacklongr2()
        {

        }

        public virtual void anm_attacklongr3()
        {

        }

        public virtual void anm_attacklongrb1()
        {

        }

        public virtual void anm_attacklongrb2()
        {

        }

        public virtual void anm_attacklongrb3()
        {

        }

        public virtual void anm_attacklongstartl1()
        {

        }

        public virtual void anm_attacklongstartl2()
        {

        }

        public virtual void anm_attacklongstartl3()
        {

        }

        public virtual void anm_attacklongstartlb1()
        {

        }

        public virtual void anm_attacklongstartlb2()
        {

        }

        public virtual void anm_attacklongstartlb3()
        {

        }

        public virtual void anm_attacklongstartr1()
        {

        }

        public virtual void anm_attacklongstartr2()
        {

        }

        public virtual void anm_attacklongstartr3()
        {

        }

        public virtual void anm_attacklongstartrb1()
        {

        }

        public virtual void anm_attacklongstartrb2()
        {

        }

        public virtual void anm_attacklongstartrb3()
        {

        }

        public virtual void anm_attacks4chargel()
        {

        }

        public virtual void anm_attacks4chargelb()
        {

        }

        public virtual void anm_attacks4charger()
        {

        }

        public virtual void anm_attacks4chargerb()
        {

        }

        public virtual void anm_attackshortendl1()
        {

        }

        public virtual void anm_attackshortendlb1()
        {

        }

        public virtual void anm_attackshortendlb3()
        {

        }

        public virtual void anm_attackshortendr1()
        {

        }

        public virtual void anm_attackshortendrb1()
        {

        }

        public virtual void anm_attackshortendrb3()
        {

        }

        public virtual void anm_attackshortl1()
        {

        }

        public virtual void anm_attackshortl2()
        {

        }

        public virtual void anm_attackshortl3()
        {

        }

        public virtual void anm_attackshortlb1()
        {

        }

        public virtual void anm_attackshortlb2()
        {

        }

        public virtual void anm_attackshortlb3()
        {

        }

        public virtual void anm_attackshortpulll2()
        {

        }

        public virtual void anm_attackshortpulll3()
        {

        }

        public virtual void anm_attackshortpulllb2()
        {

        }

        public virtual void anm_attackshortpulllb3()
        {

        }

        public virtual void anm_attackshortpullr2()
        {

        }

        public virtual void anm_attackshortpullr3()
        {

        }

        public virtual void anm_attackshortpullrb2()
        {

        }

        public virtual void anm_attackshortpullrb3()
        {

        }

        public virtual void anm_attackshortr1()
        {

        }

        public virtual void anm_attackshortr2()
        {

        }

        public virtual void anm_attackshortr3()
        {

        }

        public virtual void anm_attackshortrb1()
        {

        }

        public virtual void anm_attackshortrb2()
        {

        }

        public virtual void anm_attackshortrb3()
        {

        }

        public virtual void anm_attackshortstartl1()
        {

        }

        public virtual void anm_attackshortstartl2()
        {

        }

        public virtual void anm_attackshortstartl3()
        {

        }

        public virtual void anm_attackshortstartlb1()
        {

        }

        public virtual void anm_attackshortstartlb2()
        {

        }

        public virtual void anm_attackshortstartlb3()
        {

        }

        public virtual void anm_attackshortstartr1()
        {

        }

        public virtual void anm_attackshortstartr2()
        {

        }

        public virtual void anm_attackshortstartr3()
        {

        }

        public virtual void anm_attackshortstartrb1()
        {

        }

        public virtual void anm_attackshortstartrb2()
        {

        }

        public virtual void anm_attackshortstartrb3()
        {

        }

        public virtual void anm_specialairhiend2()
        {

        }

        public virtual void anm_specialairhistart2()
        {

        }

        public virtual void anm_specialhilong()
        {

        }

        public virtual void anm_specialhilongend()
        {

        }

        public virtual void anm_specialhishort()
        {

        }

        public virtual void anm_specialhishortend()
        {

        }

        public virtual void anm_catchairend()
        {

        }

        public virtual void anm_catchairreturn()
        {

        }

        public virtual void anm_catchattackbig()
        {

        }

        public virtual void anm_catchdashend()
        {

        }

        public virtual void anm_catchdashreturn()
        {

        }

        public virtual void anm_catchdashstart()
        {

        }

        public virtual void anm_catchend()
        {

        }

        public virtual void anm_catchpull2()
        {

        }

        public virtual void anm_catchpull2big()
        {

        }

        public virtual void anm_catchreturn()
        {

        }

        public virtual void anm_catchstart()
        {

        }

        public virtual void anm_catchturnend()
        {

        }

        public virtual void anm_catchturnreturn()
        {

        }

        public virtual void anm_catchturnstart()
        {

        }

        public virtual void anm_catchwaitbig()
        {

        }

        public virtual void anm_specialairnbite()
        {

        }

        public virtual void anm_specialairnbiteend()
        {

        }

        public virtual void anm_specialairnbitestart()
        {

        }

        public virtual void anm_specialairnopen()
        {

        }

        public virtual void anm_specialairnopenwait()
        {

        }

        public virtual void anm_specialnbite()
        {

        }

        public virtual void anm_specialnbiteend()
        {

        }

        public virtual void anm_specialnbitestart()
        {

        }

        public virtual void anm_specialnopen()
        {

        }

        public virtual void anm_specialnopenwait()
        {

        }

        public virtual void anm_specialairsbride()
        {

        }

        public virtual void anm_specialairsbump()
        {

        }

        public virtual void anm_specialairsdown()
        {

        }

        public virtual void anm_specialairssearch()
        {

        }

        public virtual void anm_specialsappeal()
        {

        }

        public virtual void anm_specialsbdrive()
        {

        }

        public virtual void anm_specialsblanding()
        {

        }

        public virtual void anm_specialsbride()
        {

        }

        public virtual void anm_specialsbump()
        {

        }

        public virtual void anm_specialsdown()
        {

        }

        public virtual void anm_specialsescape()
        {

        }

        public virtual void anm_specialsescapestart()
        {

        }

        public virtual void anm_specialssearch()
        {

        }

        public virtual void anm_specialsturnend()
        {

        }

        public virtual void anm_specialsturnloop()
        {

        }

        public virtual void anm_specialsturnstart()
        {

        }

        public virtual void anm_specialswheelie()
        {

        }

        public virtual void anm_specialswheelieend()
        {

        }

        public virtual void anm_specialswheeliestart()
        {

        }

        public virtual void anm_specialairlwflyr()
        {

        }

        public virtual void anm_specialairlwlr()
        {

        }

        public virtual void anm_specialairlwmr()
        {

        }

        public virtual void anm_specialairlwsr()
        {

        }

        public virtual void anm_speciallwflyr()
        {

        }

        public virtual void anm_speciallwlandingflyr()
        {

        }

        public virtual void anm_speciallwlandinglr()
        {

        }

        public virtual void anm_speciallwlr()
        {

        }

        public virtual void anm_speciallwmr()
        {

        }

        public virtual void anm_speciallwsr()
        {

        }

        public virtual void anm_stomach()
        {

        }

        public virtual void anm_attackhi4chargel()
        {

        }

        public virtual void anm_attackhi4l()
        {

        }

        public virtual void anm_specialsheading()
        {

        }

        public virtual void anm_specialairlwfailurel()
        {

        }

        public virtual void anm_specialairlwfailurer()
        {

        }

        public virtual void anm_specialairlwsuccessl()
        {

        }

        public virtual void anm_specialairlwsuccessr()
        {

        }

        public virtual void anm_speciallwfailurel()
        {

        }

        public virtual void anm_speciallwfailurer()
        {

        }

        public virtual void anm_speciallwsuccessl()
        {

        }

        public virtual void anm_speciallwsuccessr()
        {

        }

        public virtual void anm_capturedamagedxzitabatahi()
        {

        }

        public virtual void anm_capturedamagedxzitabatalw()
        {

        }

        public virtual void anm_capturedamagegirlzitabatahi()
        {

        }

        public virtual void anm_capturedamagegirlzitabatalw()
        {

        }

        public virtual void anm_capturedamagezitabatahi()
        {

        }

        public virtual void anm_capturedamagezitabatalw()
        {

        }

        public virtual void anm_capturedxzitabatahi()
        {

        }

        public virtual void anm_capturedxzitabatalw()
        {

        }

        public virtual void anm_capturegirlzitabatahi()
        {

        }

        public virtual void anm_capturegirlzitabatalw()
        {

        }

        public virtual void anm_capturepulleddxzitabatahi()
        {

        }

        public virtual void anm_capturepulleddxzitabatalw()
        {

        }

        public virtual void anm_capturepulledgirlzitabatahi()
        {

        }

        public virtual void anm_capturepulledgirlzitabatalw()
        {

        }

        public virtual void anm_capturepulledzitabatahi()
        {

        }

        public virtual void anm_capturepulledzitabatalw()
        {

        }

        public virtual void anm_capturezitabatahi()
        {

        }

        public virtual void anm_capturezitabatalw()
        {

        }

        public virtual void anm_win1c_us_en()
        {

        }

        public virtual void anm_win1cwait_us_en()
        {

        }

        public virtual void anm_win1d_us_en()
        {

        }

        public virtual void anm_win1dwait_us_en()
        {

        }

        public virtual void anm_win1e_us_en()
        {

        }

        public virtual void anm_win1ewait_us_en()
        {

        }

        public virtual void anm_win1f_us_en()
        {

        }

        public virtual void anm_win1fwait_us_en()
        {

        }

        public virtual void anm_win2c_us_en()
        {

        }

        public virtual void anm_win2cwait_us_en()
        {

        }

        public virtual void anm_win2d_us_en()
        {

        }

        public virtual void anm_win2dwait_us_en()
        {

        }

        public virtual void anm_win2e_us_en()
        {

        }

        public virtual void anm_win2ewait_us_en()
        {

        }

        public virtual void anm_win3c_us_en()
        {

        }

        public virtual void anm_win3cwait_us_en()
        {

        }

        public virtual void anm_win3d_us_en()
        {

        }

        public virtual void anm_win3dwait_us_en()
        {

        }

        public virtual void anm_win3e_us_en()
        {

        }

        public virtual void anm_win3ewait_us_en()
        {

        }

        public virtual void anm_visualscene()
        {

        }

        public virtual void anm_finalairfinish()
        {

        }

        public virtual void anm_finalairloop()
        {

        }

        public virtual void anm_finalloop()
        {

        }


    }
}
