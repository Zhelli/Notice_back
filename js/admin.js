document.getElementById('hide').hidden = true;
document.getElementById('hidetwo').hidden = true;
let user = 0;
let form = 0;
function ShowUsers()
{
    if(user %2 ===0)
    {
        document.getElementById('hide').hidden = false;
        user++;
    }
    else
    {
        document.getElementById('hide').hidden = true;
        user++;
    }
}
function ShowClass()
{
    if(form%2===0)
    {
        document.getElementById('hidetwo').hidden = false;
        form++;
    }
    else
    {
        document.getElementById('hidetwo').hidden = true;
        form++;
    }
}