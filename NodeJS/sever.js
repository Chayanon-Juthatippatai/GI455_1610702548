var websocket = require('ws');

var wss = new websocket.Server({port:25500},()=>{
console.log("Ruvet is running");
});

var wsList = [];

wss.on("connection",( ws , rq )=>{

    console.log('client connected.');

    wsList.push(ws);    
    
    ws.on("message",(data)=>{

        console.log(data);
        Boardcast(data);

    });

    ws.on("close",  ()=>{

        wsList = ArrayRemove(wsList, ws);
        console.log("cilent disconnected.");

    }); 

});

function ArrayRemove(arr, value){

    return arr.filter((element)=>{
        return element != value;
    })

}



function Boardcast(data)
{
    for(var  i = 0; i < wsList.length; i++)
    {
        wsList[i].send(data);
    }
}
