// Edited by: Mark Ribeiro

using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 0x13b2 , 0x13b1 )]
	public class DreamLine : Bow
	{
		public override int ArtifactRarity{ get{ return 19; } }		// Edited
		public override int EffectID{ get{ return 0xF42; } }
		public override Type AmmoType{ get{ return typeof( Arrow ); } }
		public override Item Ammo{ get{ return new Arrow(); } }

		public override int AosStrengthReq{ get{ return 30; } }
		public override int AosMinDamage{ get{ return 15; } }
		public override int AosMaxDamage{ get{ return 19; } }
		public override float MlSpeed { get { return 3.0f; } }
		
		public override int OldStrengthReq{ get{ return 30; } }
		public override int OldMinDamage{ get{ return 16; } }
		public override int OldMaxDamage{ get{ return 18; } }

		public override int DefMaxRange{ get{ return 11; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		//public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.ShootBow; } }

		[Constructable]
		public DreamLine()
		{
			Weight = 5.0;
            Name = "Dream Line";
            Hue = 2597;
			//Label1 = "Mystara Artifact";
			Attributes.WeaponDamage = 40;
	    	Attributes.AttackChance = 20;
            Attributes.WeaponSpeed = 50;
            //LootType = LootType.blessed;
			WeaponAttributes.HitLeechMana = 35;
			Layer = Layer.TwoHanded;
		}

		public DreamLine(Serial serial) : base(serial)
		{
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