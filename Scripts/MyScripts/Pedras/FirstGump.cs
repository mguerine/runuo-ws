//GM Arthanys - Mystara Shard: www.mystara.com.br

using System;
using Server;
using Server.Mobiles;
using Server.Misc;
using Server.Gumps;
using Server.Network;
using Server.Items;
using Server.Accounting;
using System.Text;
using Server.Targeting;
using System.Collections;

using Server.Multis;


namespace Server.Gumps
{
	public class FirstGump : Gump
	{
		


		public FirstGump( ) : base(300,30 )
		{



			AddPage( 0 );

			AddBackground( 0, 0, 430, 490, 5054 );
			//AddBackground( 10, 10, 180, 485, 3000 );
			//AddImage(100, 380, 30 ,1288);
			
			AddLabel( 30, 10, 1932, "All you must know about this Warshard. Have a good one." );
			
			AddHtml( 30, 40, 350, 350, "This WS has skillscap: 720.0, each skill is capped at 120.0\nStatusCap: 255, each status is capped at 125.\nRight after choose your skills, type: set skill valor.\nThats the same way for status gain: set status valor (str/int/dex).\nOnce you do not know how to write a skill, type 'help' to get a list of all skills. \nAll itens and Artifacts are in your bank. \nFor any futher information send a page. Markola's shard team is thankful. Good game.", true, true ); //bool scrollbar


			
			AddButton( 30, 425, 4006, 4007, 4, GumpButtonType.Reply, 0 );
			AddLabel( 62, 427, 1569, "Open up your bank." );


			AddButton( 25, 455, 4005, 4007, 2, GumpButtonType.Reply, 0 );
			AddLabel( 55, 457, 0x34, "List of Skills" );
			
			AddButton( 180, 455, 4005, 4007, 1, GumpButtonType.Reply, 0 );
			AddLabel( 210, 457, 0x34, "OK" );
			
			//AddButton( 270, 455, 4005, 4007, 3, GumpButtonType.Reply, 0 );
			//AddHtmlLocalized( 300, 457, 75, 20, 1011012, false, false ); // CANCEL


		
		}

 	public override void OnResponse(NetState sender, RelayInfo info)
	{
		Mobile m = sender.Mobile;

		//if (m == null)
		//return;

			switch( info.ButtonID ){

				case 0:
			
					m.SendGump (new FirstGump());
					break;
	
				case 3: 
					m.CloseGump( typeof( ItensGump ) );
					m.SendMessage("You've decided to close the help gump.");
					break;

				case 1: 
					m.CloseGump( typeof( ItensGump ) );
					m.SendMessage("Any question please send page!");
					break;
				
				case 2: // List of skills
					{
						string[] strings = Enum.GetNames( typeof( SkillName ) );

						Array.Sort( strings );

						StringBuilder sb = new StringBuilder();

						if ( strings.Length > 0 )
							sb.Append( strings[0] );

						for ( int i = 1; i < strings.Length; ++i )
						{
							string v = strings[i];

							if ( (sb.Length + 1 + v.Length) >= 256 )
							{
								sender.Send( new AsciiMessage( Server.Serial.MinusOne, -1, MessageType.Label, 0x35, 3, "System", sb.ToString() ) );
								sb = new StringBuilder();
								sb.Append( v );
							}
							else
							{
								sb.Append( ' ' );
								sb.Append( v );
							}
						}

						if ( sb.Length > 0 )
						{
							sender.Send( new AsciiMessage( Server.Serial.MinusOne, -1, MessageType.Label, 0x35, 3, "System", sb.ToString() ) );
						}

						m.SendGump (new FirstGump());
						break;
					}
				case 4:
					
					m.SendGump(new FirstGump());
					m.BankBox.Open();
					m.SendMessage("Your bank is open.");
					break;

				

			}

		

		}
			

		


	}
}