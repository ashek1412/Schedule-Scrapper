
const elementExist = setInterval(() => {
    var elm = document.querySelector("td.day.slotsavailable a");
  
    
    if (elm != null) {
        // call your function here to do something
        //console.log("slot"+elm);
        var ex = document.querySelector("#timer_stat");
        var cdate = document.querySelectorAll("div .span-7 p")[1];
        var ldate = document.querySelector("#last_date");

        if (cdate != null) {

            //console.log(cdate);
            cdate = cdate.innerText;
            var tmp = cdate.replace(/(\r\n|\n|\r|(  ))/gm, "");
            cdate = tmp.substring(tmp.indexOf('–') + 1);
            //cdate = cdate.slice(cdate.Length - 16)
            cdate = cdate.trim();           
            cdate = cdate.replace(/(\d+)(st|nd|rd|th)/g, "$1");           
            
          //  console.log("cdate : "+cdate);
            cdate = Date.parse(cdate);
                      
        }
        

        //console.log("ldate: " + ldate.innerHTML);

        if (ldate != null) {
           
            ldate = Date.parse(ldate.innerHTML);
        }

       // console.log(cdate + "-" + ldate + "-" + ex.innerHTML);

        if (ex != null && ex.innerHTML == "on")
        {           

            if (cdate != null && ldate != null && cdate <= ldate) {
                clearInterval(elementExist);
                elm.click();                
            }
        }

       
    }
}, 200);



window.onload = addElement;

function addElement() {

    const currentDiv = document.getElementById("searchResults");
    if (currentDiv != null) {
        // create a new div element

        
        let newDiv = document.createElement("div");
        newDiv.id = "timer_stat";
        newDiv.style.display = "none";
        // and give it some content
        let newContent = document.createTextNode("off");

        // add the text node to the newly created div
        newDiv.appendChild(newContent);
        currentDiv.parentNode.insertBefore(newDiv, currentDiv);

        newDiv = document.createElement("div");
        newDiv.id = "last_date";        
        let today = new Date().toISOString().slice(0, 10)
        newContent = document.createTextNode(today);
        newDiv.appendChild(newContent);
        currentDiv.parentNode.insertBefore(newDiv, currentDiv);

        newDiv = document.createElement("div");
        newDiv.id = "curr_date";
        //newDiv.style.display = "none";
        today = new Date().toISOString().slice(0, 10)
        newContent = document.createTextNode(today);
        newDiv.appendChild(newContent);
        currentDiv.parentNode.insertBefore(newDiv, currentDiv);
    }

}




