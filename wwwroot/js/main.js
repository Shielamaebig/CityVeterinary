$(document).ready(function () {

        //json token 
        var data = localStorage.getItem('token');
        var base64Url = data.split('.')[1];
        var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
        var jsonPayload = decodeURIComponent(window.atob(base64).split('').map(function (c) {
            return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
        }).join(''));
        var raw = JSON.parse(jsonPayload);
        localStorage.setItem('role', raw.display_role);
        localStorage.setItem('name', raw.display_name);
    if (localStorage.getItem("token") === null) { 
        window.location.href = "/Login";
    }
    else {
        console.log(raw.display_name);
    }

    var logNames =  $("#logName").text("Welocome! " + (raw.display_name).split(' ').slice(0, 2).join(' '));

    logout();
});

function logout(){
    $('.logout').on('click', function(){
        localStorage.clear();
        if (localStorage.getItem("token") === null) { 
            window.location.href = "/Login";
        }
        else {
            console.log('not empty');
        }
    
    });
}
