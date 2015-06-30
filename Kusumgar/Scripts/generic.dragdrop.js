
// variable declaration
var xhr;
var Url_Str;
var CallBack_Str;
var result = [];

function ClientSideUpdate() {
    var result;
    if (xhr.readyState == 4) {
        result = xhr.responseText;

        var Obj = JSON.parse(result);

        CallBack_Str(Obj);
    }
}

var InitializeDragDrop = function (elementObject, Url, CallBack, data)
{
    Url_Str = Url;

    CallBack_Str = CallBack;

        $(elementObject).on(
            'dragover',
            function (e) {
                e.preventDefault();
                e.stopPropagation();
            }
        )
        $(elementObject).on(
            'dragenter',
            function (e) {
                e.preventDefault();
                e.stopPropagation();
            }
        )
        $(elementObject).on(
            'drop',
            function (e) {
                if (e.originalEvent.dataTransfer) {
                    if (e.originalEvent.dataTransfer.files.length) {
                        e.preventDefault();
                        e.stopPropagation();
                        /*UPLOAD FILES HERE*/
                        Traverse(e.originalEvent.dataTransfer.files, data);
                    }
                }
            }
        );
}

// Loop for files
function Traverse(files, data) {

    for (var i = 0; i < files.length; i++) {
        Upload(files[i], data);
    }
}

// Upload file 
function Upload(file, data) {

    // add json class to array
    for (var i in data) {
        result.push([i, data[i]]);
    }

    xhr = new XMLHttpRequest();

    xhr.open("post", Url_Str, true);

    // Set appropriate headers
    xhr.setRequestHeader("Content-Type", "multipart/form-data");

    xhr.setRequestHeader("X-File-Name", file.name);

    xhr.setRequestHeader("X-File-Size", file.size);

    xhr.setRequestHeader("X-File-Type", file.type);

    for (var i = 0 ; i < result.length; i++)
    {
        var j = 0;

        var key = result[i][j];

        var value = $(result[i][j + 1]).val();

        xhr.setRequestHeader(key, value);
    }
 
    // re initialize array
    result = [];

    xhr.onreadystatechange = ClientSideUpdate;
    // Send the file
    xhr.send(file);
}