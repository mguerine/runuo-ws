using System;
using Server.Network;

namespace Server.Misc
{
	/// <summary>
	/// This timer spouts some welcome messages to a user at a set interval. It is used on character creation and login.
	/// </summary>
	public class WelcomeTimer : Timer
	{
		private Mobile m_Mobile;
		private int m_State, m_Count;

		private static string[] m_Messages = ( TestCenter.Enabled ?
			new string[]
				{
					"Welcome to Markola's WarShard!",
					"You can mix up your skills and stats.",
					"Type 'help' for informations about all commands available.",
					"Skillcap 720, StatusCap 255.",
					"All itens are in your bank.",
					"Any questions or bug reports, please send page."
				} :
			new string[]
				{	//Yes, this message is a pathetic message, It's suggested that you change it.
					"Welcome to this shard.",
					"Please enjoy your stay."
				} );

		public WelcomeTimer( Mobile m ) : this( m, m_Messages.Length )
		{
		}

		public WelcomeTimer( Mobile m, int count ) : base( TimeSpan.FromSeconds( 5.0 ), TimeSpan.FromSeconds( 10.0 ) )
		{
			m_Mobile = m;
			m_Count = count;
		}

		protected override void OnTick()
		{
			if ( m_State < m_Count )
				m_Mobile.SendMessage( 0x35, m_Messages[m_State++] );

			if ( m_State == m_Count )
				Stop();
		}
	}
}