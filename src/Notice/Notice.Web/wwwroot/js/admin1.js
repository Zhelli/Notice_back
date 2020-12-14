if(document.getElementById('hide').hidden !== null){
    document.getElementById('hide').hidden = true;
}
let form = 0;
function ShowClass()
{
    if(form%2===0)
    {
        document.getElementById('hide').hidden = false;
        form++;
    }
    else
    {
        document.getElementById('hide').hidden = true;
        form++;
    }
}
