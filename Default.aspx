<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
         CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script type="text/javascript" src="sliderengine/jquery.js"></script>
    <script type="text/javascript" src="sliderengine/amazingslider.js"></script>
    <link rel="stylesheet" type="text/css" href="sliderengine/amazingslider-1.css"/>
    <script type="text/javascript" src="sliderengine/initslider-1.js"></script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to MasterMind School
    </h2>
    <div id="amazingslider-wrapper-1" style="display:block;position:relative;max-width:920px;margin:0px auto 56px; ">
        <div id="amazingslider-1" style="display:block;position:relative;margin:0 auto;width: 920px;">
            <ul class="amazingslider-slides" style="display:none;">
                <li><img src="./Image/cma1.jpg" alt="logo"  title="MASTERMIND" data-description="Student" />
                </li>
                <li><img src="./Image/cma2.jpg" alt="Gallary 1"  title="MASTERMIND" />
                </li>
               <li><img src="./Image/cma3.jpg" alt="Gallary 2"  title="MASTERMIND" />
                </li>
                <li><img src="./image/cma4.jpg" alt="Gallary 3"  title="MASTERMIND" />
               <%--  </li>
                <li><img src="../../images/cma5.jpg" alt="Gallary 4"  title="Gallary 4" />
                </li>
                <li><img src="../../images/cma6.jpg" alt="Gallary 4"  title="Gallary 4" />
                </li>
                <li><img src="../../images/cma7.png" alt="Gallary 4"  title="Gallary 4" />
                </li>
                <li><img src="../../images/cma8.jpg" alt="Gallary 4"  title="Gallary 4" />
                </li>
                <li><img src="../../images/cma9.jpg" alt="Gallary 4"  title="Gallary 4" />
                </li>
                <li><img src="../../images/cma10.jpg" alt="Gallary 4"  title="Gallary 4" />
                </li>
                <li><img src="../../images/cma11.jpg" alt="Gallary 4"  title="Gallary 4" />
                </li>--%>
                
            </ul>
            <ul class="amazingslider-thumbnails" style="display:none;">
                <li><img src="./image/cma1.jpg" alt="logo" title="MASTERMIND" /></li>
                <li><img src="./image/cma2.jpg" alt="Gallary 1" title="MASTERMIND" /></li>
                <li><img src="./image/cma3.jpg" alt="Gallary 2" title="MASTERMIND" /></li>
                <li><img src="./image/cma4.jpg" alt="Gallary 3" title="MASTERMIND" /></li>
                <%--<li><img src="../../images/cma5.jpg" alt="Gallary 4" title="Gallary 4" /></li>
                <li><img src="../../images/cma6.jpg" alt="Gallary 4" title="Gallary 4" /></li>
                <li><img src="../../images/cma7.png" alt="Gallary 4" title="Gallary 4" /></li>
                <li><img src="../../images/cma8.jpg" alt="Gallary 4" title="Gallary 4" /></li>
                <li><img src="../../images/cma9.jpg" alt="Gallary 4" title="Gallary 4" /></li>
                <li><img src="../../images/cma10.jpg" alt="Gallary 4" title="Gallary 4" /></li>
                <li><img src="../../images/cma11.jpg" alt="Gallary 4" title="Gallary 4" /></li>--%>
            </ul>
        </div>
    </div>
 
</asp:Content>