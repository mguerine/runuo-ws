using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests
{	
	public class ThinningTheHerdQuest : BaseQuest
	{				
		/* Thinning the Herd */
		public override object Title{ get{ return 1072249; } }
		
		/* Psst!  Hey ... psst!  Listen, I need some help here but it's gotta be hush hush.  I 
		don't want THEM to know I'm onto them.  They watch me.  I've seen them, but they don't 
		know that I know what I know.  You know?  Anyway, I need you to scare them off by killing 
		a few of them.  That'll send a clear message that I won't suffer goats watching me! */	
		public override object Description{ get{ return 1072263; } }
		
		/* Well, okay. But if you decide you are up for it after all, c'mon back and see me. */
		public override object Refuse{ get{ return 1072270; } }
		
		/* You're not quite done yet.  Get back to work! */
		public override object Uncomplete{ get{ return 1072271; } }
	
		public ThinningTheHerdQuest() : base()
		{			
			AddObjective( new SlayObjective( typeof( Goat ), "goats", 10 ) );
			
			AddReward( new BaseReward( typeof( SmallTrinketBag ), 1072268 ) );
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}
		
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}		
	}	

	public class Clehin : MondainQuester
	{
		public override Type[] Quests
		{ 
			get{ return new Type[] 
			{ 
				typeof( CreepyCrawliesQuest ),
				typeof( MongbatMenaceQuest ),
				typeof( SpecimensQuest ),
				typeof( ThinningTheHerdQuest )
			};} 
		}
		
		[Constructable]
		public Clehin() : base( "Clehin", "the soil nurturer" )
		{			
			SetSkill( SkillName.Meditation, 60.0, 83.0 );
			SetSkill( SkillName.Focus, 60.0, 83.0 );
		}
		
		public Clehin( Serial serial ) : base( serial )
		{
		}		
		
		public override void InitBody()
		{
			InitStats( 100, 100, 25 );
			
			Female = true;
			Race = Race.Elf;
			
			Hue = 0x8362;
			HairItemID = 0x2FC2;
			HairHue = 0x324;
		}
		
		public override void InitOutfit()
		{
			AddItem( new ElvenBoots() );
			AddItem( new LeafTonlet() );
			AddItem( new ElvenShirt() );
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}
		
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}