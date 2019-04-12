function onSignIn(googleUser) {
  var profile = googleUser.getBasicProfile();
  //console.log('ID: ' + profile.getId());
  //console.log('Name: ' + profile.getName());
  //console.log('Image URL: ' + profile.getImageUrl());
    //console.log('Email: ' + profile.getEmail());
    $("#google-name").text(profile.getName());
    $("#google-avatar-img").attr("src", profile.getImageUrl());
    $("#google-sign-in").hide();
    $("#google-account").show();
}


function signOut() {
    var auth2 = gapi.auth2.getAuthInstance();
    auth2.signOut().then(function () {
        console.log('User signed out.');
    });
    $("#google-sign-in").show();
    $("#google-account").hide();
    $(".popover").popover("hide");
}
