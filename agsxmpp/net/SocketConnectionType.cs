/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Copyright (c) 2003-2008 by AG-Software 											 *
 * All Rights Reserved.																 *
 * Contact information for AG-Software is available at http://www.ag-software.de	 *
 *																					 *
 * Licence:																			 *
 * The agsXMPP SDK is released under a dual licence									 *
 * agsXMPP can be used under either of two licences									 *
 * 																					 *
 * A commercial licence which is probably the most appropriate for commercial 		 *
 * corporate use and closed source projects. 										 *
 *																					 *
 * The GNU Public License (GPL) is probably most appropriate for inclusion in		 *
 * other open source projects.														 *
 *																					 *
 * See README.html for details.														 *
 *																					 *
 * For general enquiries visit our website at:										 *
 * http://www.ag-software.de														 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using System;

namespace agsXMPP.net
{
	/// <summary>
	/// Summary description for SocketType.
	/// </summary>
	public enum SocketConnectionType
	{
#if !SL
		/// <summary>
		/// Direct TCP/IP Connection
		/// </summary>
		Direct,
#endif	
		/// <summary>
		/// A HTTP Polling Socket connection (JEP-0025)
		/// </summary>
		HttpPolling,

        /// <summary>
        /// <para>XEP-0124: Bidirectional-streams Over Synchronous HTTP (BOSH)</para>
        /// <para>http://www.xmpp.org/extensions/xep-0124.html</para>
        /// </summary>
        Bosh
	}
}
