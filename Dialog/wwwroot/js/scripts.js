$(document).ready(function(){
  var datedivs = $(".time-of-post")
  for (var i = 0; i < datedivs.length; i++) {
    var datediv = datedivs[i];
    var stringDate = $(datediv).attr("value")

    var date = new Date(stringDate + " UTC")
    console.log(date);
    var localeString = date.toLocaleString()
    localeString = localeString.replace(", ", " </br> ")
    $(datediv).append("Posted: " + localeString);
  }
});
