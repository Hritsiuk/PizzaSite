
function setCookie(cname,cvalue,exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays*24*60*60*1000));
    var expires = "expires=" + d.toGMTString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
  }
  
function getCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    
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
function has(arr,elem) {

    for (var i = 0; i < arr.length; i++) {
        if (arr[i].name === elem) {
            return true;
        }
    }
    return false;
}


function addcount(pname,pcount,money) {

    

    
    
   
    var user = getCookie("username");
    var json;
 
        json = JSON.parse(user);

    let temp = 0;
    console.log(pcount);
    for (var i = 0; i < json.arr.length; i++) {
        if (json.arr[i].name === pname) {
            
            temp = json.arr[i].count;
           

            json.arr[i].count = pcount;
            console.log(json.arr[i].count);
        }
     }
        user = JSON.stringify(json);
    minuscount(-(pcount - temp));
    minussum(-((pcount - temp) * money))
    console.log(pcount - temp);
    if (user != "" && user != null) {
        setCookie("username", user, 30);


    }
}

function checkCookie(pname , pcount, pidt,count,money) {
    var user = getCookie("username");
    var json;
    if (user != "") {
        json = JSON.parse(user);

        if (!has(json.arr, pname)) {

            json.arr.push({ name: pname, count: pcount, idt: pidt, componentid: ""});
        }
        else {
            for (var i = 0; i < json.arr.length; i++) {
                if (json.arr[i].name === pname) {
                    json.arr[i].count += pcount;
                }
            }
        }



        user = JSON.stringify(json);

    }
    else {
        

        user = {

            arr: []
        };

        user.arr.push({ name: pname, count: pcount, idt: pidt, componentid: ""});
        json = JSON.stringify(user);

       

        user = json;
    }
    settotal(count, money);
  
       
     
        
        if (user != "" && user != null) {
            setCookie("username", user, 30);

            
        }
    
}

function checkCookie2(pname, pcount, pidt, count, money,pcomponentid) {
    var user = getCookie("username");
    var json;
    if (user != "") {
        json = JSON.parse(user);

        if (!has(json.arr, pname)) {

            json.arr.push({ name: pname, count: pcount, idt: pidt, componentid: pcomponentid});
        }
        else {
            for (var i = 0; i < json.arr.length; i++) {
                if (json.arr[i].name === pname) {
                    json.arr[i].count += pcount;
                }
            }
        }



        user = JSON.stringify(json);

    }
    else {


        user = {

            arr: []
        };

        user.arr.push({ name: pname, count: pcount, idt: pidt, componentid: pcomponentid });
        json = JSON.stringify(user);



        user = json;
    }
    settotal(count, money);




    if (user != "" && user != null) {
        setCookie("username", user, 30);


    }

}



function delelementbyid(id,money=0)
{
    
    var temp = getCookie("username");
    var temp2 = JSON.parse(temp);
    for (var i = 0; i < temp2.arr.length; i++) {


        
        if (temp2?.arr[i]?.name === id ) {
            if (temp2?.arr[i]?.count != 0) {
                minussum(money * temp2?.arr[i]?.count);
            }
            
            minuscount(temp2?.arr[i]?.count);
            temp2.arr.splice(i, 1);
            i--;
        }

    }
   
    var user = JSON.stringify(temp2);
    
    setCookie("username", user, 30);
}

function del(btn,id,money) {

   
    
    btn.parentElement.parentElement.parentElement.parentElement.remove();
    delelementbyid(id,money);
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


  

    if (user != "" && user != null) {
        setCookie("total", user, 30);
        redact();

    }

   

}
function minustotal(count, money) {
    var user = getCookie("total");
    var json;
    if (user != "") {
        json = JSON.parse(user);
        json.arr2[0].money -= money;
        json.arr2[0].count -= count;


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


  

    if (user != "" && user != null) {
        setCookie("total", user, 30);
        redact();

    }



}
function minussum(money) {
    var user = getCookie("total");
    var json;
    if (user != "") {
        json = JSON.parse(user);
        json.arr2[0].money -= money;
        


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




    if (user != "" && user != null) {
        setCookie("total", user, 30);
        redact();

    }



}
function minuscount(count) {
    var user = getCookie("total");
    var json;
    if (user != "") {
        json = JSON.parse(user);
      
        json.arr2[0].count -= count;


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


  

    if (user != "" && user != null) {
        setCookie("total", user, 30);
        redact();

    }



}