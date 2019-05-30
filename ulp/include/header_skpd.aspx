<table width="100%"  border="0" cellpadding="0" cellspacing="0" style="background-repeat:no-repeat">
  <tr>
    <td  align="left"  style="width: 100%; background:repeat url(images/HeaderulpFill.jpg);">
	<img src="images/Headerulp1.jpg"   />
    </td>
  </tr>
  
</table>

<div id="menu">
    <ul>
    <li><a href='menu.aspx'>Home</a></li>
    <li><a href='#'>Pengadaan Barang/Jasa</a>
      <ul>
        <li><a href='PENGADAAN_LANGSUNG_list.aspx?a=search&value=1&SearchFor=<%=Session["pusername"]%>&SearchOption=Equals&SearchField=PEJABATPENGADAAN'>Perekaman Pengadaan Langsung</a></li>
      </ul>
    </li>
    <li><a href='#'>Reporting</a>
      <ul>
        <li><a href='RPTPENGADAANLANGSUNG.aspx?usrgrp=SKPD'>Daftar pengadaan langsung di SKPD</a></li>
      </ul>
    </li>
    </ul>
</div>
