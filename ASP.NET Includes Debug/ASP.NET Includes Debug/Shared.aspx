<!--#include virtual="header.aspx"-->

<script runat="server">

    Sub Page_Load()
        test()
    End Sub

    Sub test()
        localSpan.InnerHtml = "Local Script Edit"

        headerSpan.InnerHtml = "Other file Script Edit"
    End Sub
</script>

<span id="localSpan" runat="server"></span><br /><br />