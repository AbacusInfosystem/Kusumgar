function Friendly_Message(data) {
    if (data.Friendly_Message.length > 0) {
        var message = "";
        var messageType = "";

        for (var i = 0; i < data.Friendly_Message.length; i++) {
            switch (data.Friendly_Message[i].Type) {
                case 1:
                    messageType = "Info";
                    break;
                case 2:
                    messageType = "Danger";
                    break;
                case 3:
                    messageType = "Success";
                    break;
                case 4:
                    messageType = "Warning";
                    break;
            }

            if (messageType == "Info") {
                message += "<div class='alert alert-info alert-dismissable'>"
                message += "<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>";
                message += "<h4><i class='icon fa fa-info'></i> Alert!</h4>";
                message += data.Friendly_Message[i].Text;
                message += " </div>";
            }
            else if (messageType == "Danger") {
                message += "<div class='alert alert-danger alert-dismissable'>"
                message += "<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>";
                message += "<h4><i class='icon fa fa-ban'></i> Alert!</h4>";
                message += data.Friendly_Message[i].Text;
                message += " </div>";
            }
            else if (messageType == "Success") {
                message += "<div class='alert alert-success alert-dismissable'>"
                message += "<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>";
                message += "<h4><i class='icon fa fa-check'></i> Alert!</h4>";
                message += data.Friendly_Message[i].Text;
                message += " </div>";
            }
            else {
                message += "<div class='alert alert-warning alert-dismissable'>"
                message += "<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>";
                message += "<h4><i class='icon fa fa-warning'></i> Alert!</h4>";
                message += data.Friendly_Message[i].Text;
                message += " </div>";
            }
        }
    }
    $('#message').append(message);

    $("#message").find('.alert').fadeOut(2000);
}