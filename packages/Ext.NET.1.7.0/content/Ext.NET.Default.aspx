<%@ Page Language="C#" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<script runat="server">
    protected void Button1_Click(object sender, DirectEventArgs e)
    {
        X.Msg.Notify("Message", this.TextField1.Text).Show();
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ext.NET Example</title>
</head>
<body>
    <form runat="server">
        <ext:ResourceManager runat="server" />
        
        <a href="http://www.ext.net/"><img src="http://speed.ext.net/identity/extnet-logo-small.png" /></a>

        <ext:Window 
            ID="Window1"
            runat="server" 
            Title="Welcome to Ext.NET 1"
            Padding="5"
            Height="215"
            Width="350"
            Layout="FormLayout"
            DefaultAnchor="100%">
            <Items>
                <ext:TextField ID="TextField1" runat="server" FieldLabel="Message" />
            </Items>
            <Buttons>
                <ext:Button ID="Button1" runat="server" Text="Submit" OnDirectClick="Button1_Click" />
            </Buttons>
        </ext:Window>
    </form>
</body>
</html>