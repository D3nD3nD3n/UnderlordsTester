﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UnderlordsTracker.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("UnderlordsTracker.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to F3 0F11 8F 94060000   - movss [rdi+00000694],xmm1			- Increment server timer
        ///52                    - push rdx							- Store rdx
        ///48 8B 15 7D000000     - mov rdx,[Data]						- Move player index
        ///48 83 FA 00           - cmp rdx,00							- if player index isn&apos;t 0
        ///74 68                 - je Exit
        ///90                    - nop 
        ///90                    - nop 
        ///90                    - nop 
        ///90                    - nop 
        ///55                    - push rbp
        ///41 50                 - push r8
        ///41 51                 - push  [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string AddHeroInjection {
            get {
                return ResourceManager.GetString("AddHeroInjection", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 1,brawny warrior
        ///2,savage druid
        ///3,ogre mage
        ///4,savage warrior
        ///5,undead hunter
        ///6,goblin assassin
        ///7,goblin inventor
        ///8,troll shaman
        ///9,troll knight
        ///10,goblin inventor
        ///11,elf demonhunter
        ///12,primordial warrior
        ///13,human mage
        ///14,brawny hunter
        ///15,brawny warrior
        ///16,goblin inventor
        ///17,demon assassin
        ///18,elf dragon mage
        ///19,troll warlock
        ///20,naga warrior
        ///21,demon knight
        ///22,elf druid
        ///23,primordial assassin
        ///24,elf knight
        ///25,elf druid
        ///26,human savage hunter
        ///27,savage warlock
        ///28,human knight
        ///29,prim [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string HeroAlliances {
            get {
                return ResourceManager.GetString("HeroAlliances", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Icons {
            get {
                object obj = ResourceManager.GetObject("Icons", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap IconsMini {
            get {
                object obj = ResourceManager.GetObject("IconsMini", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 1,dac_hero_name_axe
        ///2,dac_hero_name_enchantress
        ///3,dac_hero_name_ogre_magi
        ///4,dac_hero_name_tusk
        ///5,dac_hero_name_drow_ranger
        ///6,dac_hero_name_bounty_hunter
        ///7,dac_hero_name_clockwerk
        ///8,dac_hero_name_shadow_shaman
        ///9,dac_hero_name_bat_rider
        ///10,dac_hero_name_tinker
        ///11,dac_hero_name_antimage
        ///12,dac_hero_name_tiny
        ///13,dac_hero_name_crystal_maiden
        ///14,dac_hero_name_beast_master
        ///15,dac_hero_name_juggernaut
        ///16,dac_hero_name_timbersaw
        ///17,dac_hero_name_queen_of_pain
        ///18,dac_hero_name_puck
        ///19,dac_hero_name_ [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string IDtoName {
            get {
                return ResourceManager.GetString("IDtoName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 	&quot;dac_hero_name_abaddon&quot;								&quot;Abaddon&quot;
        ///	&quot;dac_hero_name_alchemist&quot;							&quot;Alchemist&quot;
        ///	&quot;dac_hero_name_antimage&quot;							&quot;Anti-Mage&quot;
        ///	&quot;dac_hero_name_axe&quot;									&quot;Axe&quot;
        ///	&quot;dac_hero_name_bat_rider&quot;							&quot;Batrider&quot;
        ///	&quot;dac_hero_name_beast_master&quot;						&quot;Beastmaster&quot;
        ///	&quot;dac_hero_name_bounty_hunter&quot;						&quot;Bounty Hunter&quot;
        ///	&quot;dac_hero_name_chaos_knight&quot;						&quot;Chaos Knight&quot;
        ///	&quot;dac_hero_name_clockwerk&quot;							&quot;Clockwerk&quot;
        ///	&quot;dac_hero_name_crystal_maiden&quot;						&quot;Crystal Maiden&quot;
        ///	&quot;dac_hero_name_disruptor&quot;							&quot;Disrupto [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Translation {
            get {
                return ResourceManager.GetString("Translation", resourceCulture);
            }
        }
    }
}
