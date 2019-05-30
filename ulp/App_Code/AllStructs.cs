using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;

namespace Data
{
	#region Tables Struct
	public partial struct Tables
	{
		int i;
		
		public static string AKTOR = @"AKTOR";
        
		public static string ASSIGNMENT = @"ASSIGNMENT";
        
		public static string DOKUMEN = @"DOKUMEN";
        
		public static string JABATANAKTOR = @"JABATANAKTOR";
        
		public static string JENISKEGIATAN = @"JENISKEGIATAN";
        
		public static string KELENGKAPAN = @"KELENGKAPAN";
        
		public static string KELENGKAPANPBJ = @"KELENGKAPANPBJ";
        
		public static string KELOMPOKPENGGUNA = @"KELOMPOKPENGGUNA";
        
		public static string PBJ = @"PBJ";
        
		public static string PENGGUNA = @"PENGGUNA";
        
		public static string SKPD = @"SKPD";
        
		public static string STATUSPBJ = @"STATUSPBJ";
        
		public static string TIPEAKTOR = @"TIPEAKTOR";
        
	}

	#endregion
    #region View Struct
    public partial struct Views 
    {
		int i;
		
    }

    #endregion
}

#region Databases
public partial struct Databases 
{
	int i;
	
	public static string MyProvider = @"MyProvider";
    
}

#endregion
