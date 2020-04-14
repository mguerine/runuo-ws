//GM Arthanys - Mystara Shard: www.mystara.com.br

using System;
using Server;
using Server.Mobiles;
using Server.Misc;
using Server.Gumps;
using System.Text;
using Server.Network;
using Server.Items;
using Server.Accounting;

using Server.Multis;


namespace Server.Gumps
{
	public class StatGump : Gump
	{
		


		public StatGump( ) : base(300,30 )
		{



			AddPage( 0 );

			AddBackground( 0, 0, 200, 505, 5054 );
			AddBackground( 10, 10, 180, 485, 3000 );
			//AddImage(100, 200, 30);
			
			AddLabel( 50, 20, 0x5, "Status Gump" );
			
			AddButton( 30, 55, 4005, 4007, 1, GumpButtonType.Reply, 0 );
			AddLabel( 62, 55, 0x34, "Hits 100%" );

			AddButton( 30, 85, 4005, 4007, 2, GumpButtonType.Reply, 0 );
			AddLabel( 62, 85, 0x34, "Mana 100%" );

			AddButton( 30, 115, 4005, 4007, 3, GumpButtonType.Reply, 0 );
			AddLabel( 62, 115, 0x34, "Stam 100%" );

			AddButton( 30, 145, 4005, 4007, 4, GumpButtonType.Reply, 0 );
			AddLabel( 62, 145, 0x34, "Karma 0" );

			AddButton( 30, 175, 4005, 4007, 5, GumpButtonType.Reply, 0 );
			AddLabel( 62, 175, 0x34, "Karma +15k" );

			AddButton( 30, 205, 4005, 4007, 6, GumpButtonType.Reply, 0 );
			AddLabel( 62, 205, 0x34, "Karma -15k" );

			AddButton( 30, 235, 4005, 4007, 7, GumpButtonType.Reply, 0 );
			AddLabel( 62, 235, 0x34, "Fame 0" );

			AddButton( 30, 265, 4005, 4007, 8, GumpButtonType.Reply, 0 );
			AddLabel( 62, 265, 0x34, "Fame 15k" );

			AddButton( 30, 295, 4005, 4007, 9, GumpButtonType.Reply, 0 );
			AddLabel( 62, 295, 0x34, "0 Kills(blue)" );

			AddButton( 30, 325, 4005, 4007, 10, GumpButtonType.Reply, 0 );
			AddLabel( 62, 325, 0x34, "100 kills(pk)" );

			AddButton( 30, 355, 4005, 4007, 11, GumpButtonType.Reply, 0 );
			AddLabel( 62, 355, 0x34, "Reset all skills" );

			AddButton( 30, 385, 4005, 4007, 12, GumpButtonType.Reply, 0 );
			AddLabel( 62, 385, 0x34, "Reset Status" );

			AddButton( 30, 415, 4005, 4007, 13, GumpButtonType.Reply, 0 );
			AddLabel( 62, 415, 0x34, "Auto Kill" );

			AddButton( 30, 445, 4005, 4007, 14, GumpButtonType.Reply, 0 );
			AddLabel( 62, 445, 0x34, "Karma/Fame/Kills" );

			AddButton( 88, 475, 4005, 4007, 0, GumpButtonType.Reply, 0 );
			AddHtmlLocalized( 122, 477, 75, 20, 1011012, false, false ); // CANCEL
		}

 	public override void OnResponse(NetState sender, RelayInfo info)
	{
		Mobile m = sender.Mobile;

		//if (m == null)
		//return;

			switch( info.ButtonID ){
				case 0: 
					m.CloseGump( typeof( StatGump ) );
					return;
				
				case 1:
					m.Hits = m.HitsMax;
					m.SendMessage("Your life is full.");
					break;
				case 2:
					m.Mana = m.ManaMax;
					m.SendMessage("Your mana is full.");
					break;
				case 3:
					m.Stam = m.StamMax;
					m.SendMessage("Your stamina is full.");
					break;
				case 4:
					m.Karma= 0;
					m.SendMessage("Karma 0");
					break;
				case 5:
					m.Karma= 15000;
					m.SendMessage("Karma 15000");
					break;
				case 6:
					m.Karma= -15000;
					m.SendMessage("Karma -15000");
					break;
				case 7:
					m.Fame= 0;
					m.SendMessage("Fame 0");
					break;
				case 8:
					m.Fame=15000;
					m.SendMessage("Fame 15000");
					break;
				case 9:
					m.Kills = 0;
					m.SendMessage("You're not a killer.");
					break;
				case 10:
					m.Kills = 100;
					m.SendMessage("You're a killer.");
					break;
				case 11:

					m.Skills[SkillName.Chivalry].Base=0;
					m.Skills[SkillName.Alchemy].Base = 0;
					m.Skills[SkillName.Anatomy].Base = 0;
					m.Skills[SkillName.AnimalLore].Base = 0;
					m.Skills[SkillName.AnimalTaming].Base = 0;
					m.Skills[SkillName.Archery].Base = 0;
					m.Skills[SkillName.ArmsLore].Base = 0;
					m.Skills[SkillName.Begging].Base = 0;
					m.Skills[SkillName.Blacksmith].Base = 0;
					m.Skills[SkillName.Camping].Base = 0;
					m.Skills[SkillName.Carpentry].Base = 0;
					m.Skills[SkillName.Cartography].Base = 0;
					m.Skills[SkillName.Cooking].Base = 0;
					m.Skills[SkillName.DetectHidden].Base = 0;
					m.Skills[SkillName.Discordance].Base = 0;
					m.Skills[SkillName.EvalInt].Base = 0;
					m.Skills[SkillName.Fishing].Base = 0;
					m.Skills[SkillName.Fencing].Base = 0;
					m.Skills[SkillName.Fletching].Base = 0;
					m.Skills[SkillName.Focus].Base = 0;
					m.Skills[SkillName.Forensics].Base = 0;
					m.Skills[SkillName.Healing].Base = 0;
					m.Skills[SkillName.Herding].Base = 0;
					m.Skills[SkillName.Hiding].Base = 0;
					m.Skills[SkillName.Inscribe].Base = 0;
					m.Skills[SkillName.ItemID].Base = 0;
					m.Skills[SkillName.Lockpicking].Base = 0;
					m.Skills[SkillName.Lumberjacking].Base = 0;
					m.Skills[SkillName.Macing].Base = 0;
					m.Skills[SkillName.Magery].Base = 0;
					m.Skills[SkillName.MagicResist].Base = 0;
					m.Skills[SkillName.Meditation].Base = 0;
					m.Skills[SkillName.Mining].Base = 0;
					m.Skills[SkillName.Musicianship].Base = 0;
					m.Skills[SkillName.Parry].Base = 0;
					m.Skills[SkillName.Peacemaking].Base = 0;
					m.Skills[SkillName.Poisoning].Base = 0;
					m.Skills[SkillName.Provocation].Base = 0;
					m.Skills[SkillName.RemoveTrap].Base = 0;
					m.Skills[SkillName.Snooping].Base = 0;
					m.Skills[SkillName.SpiritSpeak].Base = 0;
					m.Skills[SkillName.Stealing].Base = 0;
					m.Skills[SkillName.Stealth].Base = 0;
					m.Skills[SkillName.Swords].Base = 0;
					m.Skills[SkillName.Tactics].Base = 0;
					m.Skills[SkillName.Tailoring].Base = 0;
					m.Skills[SkillName.TasteID].Base = 0;
					m.Skills[SkillName.Tinkering].Base = 0;
					m.Skills[SkillName.Tracking].Base = 0;
					m.Skills[SkillName.Veterinary].Base = 0;
					m.Skills[SkillName.Wrestling].Base = 0;
					m.Skills[SkillName.Bushido].Base = 0;
					m.Skills[SkillName.Ninjitsu].Base = 0;
					m.Skills[SkillName.Necromancy].Base = 0;
					
					m.SendMessage("All skills were reseted.");
					break;
				case 12:
					m.Str = 10;
					m.Dex = 10;
					m.Int = 10;
					m.SendMessage("Status reseted.");
					break;
				case 13:
					m.Kill();
					m.SendMessage("You killed yourself.");
					break;
				case 14:

					m.SendMessage("You have {0} Karma\n{1} Fame\n{2} Kill{3}",m.Karma,m.Fame,m.Kills, m.Kills>1 ? "s" : "" );
					break;

				

			}
			m.SendGump (new StatGump());

			

	     }
			

		


	}
}