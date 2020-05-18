$(document).ready(function () {  
    
    $('.login-form').submit(function (e) {
        e.preventDefault();
        let username = $("#username-input").val();
        let password = $("#password-input").val();
        $.ajax({
            headers: { 
                'Accept': 'application/json',
                'Content-Type': 'application/json' 
            },
            type: 'GET',
            url: `api/getuserbyname`,
            data: JSON.stringify({
                UserName: username,
                Password: password
            }),
            success: function () {
                console.log("wadsdaw");
            },
            error: function () {                
                console.log("zzzzz")
            }
        });
    });


});