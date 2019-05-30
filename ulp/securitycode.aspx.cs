#region " using "
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Collections;
using System.IO;
using System.Web.UI.WebControls;
#endregion

public partial class CSecurityCode: System.Web.UI.Page
{
    string randString(string stype, int ct)
    {
	    string randStr="";
	    int randNum=0;
	    string useList="";
	    string alpha="A,B,C,D,E,F,G,H,I,J,K,L,M,N,P,Q,R,S,T,U,V,W,X,Y,Z,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
	    string secure="!,@,$,%,&,*,-,_,=,+,?,~";
	    if(stype == "alpha")
	    {
		    randNum=52;
		    useList=alpha;
	    }
	    else if(stype=="alphanum")
	    {
		    randNum=62;
		    useList=alpha + ",1,2,3,4,5,6,7,8,9";
	    }
	    else if(stype=="secure")
	    {
		    randNum=73;
		    useList=alpha + ",0,1,2,3,4,5,6,7,8,9," + secure;
	    }
	    else
	    {
		    randNum=10;
		    useList="0,1,2,3,4,5,6,7,8,9";
	    }

	    
	    string[] arr = useList.Split(new char[]{','});
	    randNum = arr.Length;
        System.Random rand = new Random();
	    for(int i=0;i<ct;i++)
	    {
		    randStr = randStr + arr[rand.Next(0,randNum-1)];
	    }
	    return randStr;
    }

    private void Page_Load( object sender,  System.EventArgs e)
    {
        Session["captcha"] = randString("alphanum",6);
        Response.Write("&securitycode=" + Session["captcha"] + "&");
        Response.End();
    }
}