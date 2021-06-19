
function setCookie(cname,cvalue,exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays*24*60*60*1000));
    var expires = "expires=" + d.toGMTString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
  }
  
function getCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    console.log(decodedCookie);
    var ca = decodedCookie.split(';');
    for(var i = 0; i < ca.length; i++) {
      var c = ca[i];
      while (c.charAt(0) == ' ') {
        c = c.substring(1);
      }
      if (c.indexOf(name) == 0) {
        return c.substring(name.length, c.length);
      }
    }
    return "";
  }
  
function checkCookie(pname,pcount, pidt,count,money) {
    var user = getCookie("username");
    var json;
    if (user != "") {
        json = JSON.parse(user);
        json.arr.push({ name: pname, count: pcount, idt: pidt});
        user = JSON.stringify(json);

    }
    else {
        

        user = {

            arr: []
        };

        user.arr.push({ name: pname, count: pcount, idt: pidt});
        json = JSON.stringify(user);

       

        user = json;
    }
    settotal(count, money)
    {

    }
       
        console.log(json);
       
        
        
        
        console.log(user);
        
        if (user != "" && user != null) {
            setCookie("username", user, 30);

            
        }
    
}


function delelementbyid(id)
{
    
    var temp = getCookie("username");
    var temp2 = JSON.parse(temp);
    for (var i = 0; i <3; i++) {

        console.log(temp2);
        console.log(temp2.arr[i]);
        if (temp2?.arr[i]?.name === id) {
           
            temp2.arr.splice(i, 1);
            i--;
        }

    }
   
    var user = JSON.stringify(temp2);
    console.log(user);
    setCookie("username", user, 30);
}

function del(btn,id) {



    btn.parentElement.parentElement.parentElement.parentElement.remove();
    delelementbyid(id);
}

function redact() {
    var user = getCookie("total");
    var json=JSON.parse(user);

    document.getElementById("totalcount").innerHTML = json.arr2[0].count;
    document.getElementById("totalmoney").innerHTML = json.arr2[0].money;
                                        
}
function settotal(count, money) {
    var user = getCookie("total");
    var json;
    if (user != "") {
        json = JSON.parse(user);
        json.arr2[0].money += money;
        json.arr2[0].count += count;


        user = JSON.stringify(json);

    }
    else {


        user = {

            arr2: []
        };

        user.arr2.push({ count: count, money: money });
        json = JSON.stringify(user);



        user = json;
    }


    console.log(json);




    console.log(user);

    if (user != "" && user != null) {
        setCookie("total", user, 30);
        redact();

    }


}