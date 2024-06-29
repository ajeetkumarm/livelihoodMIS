//function trim(str)
//{
//    return (str.replace('^\s*','').replace('\s*$',''))
//}
function ValidateDate(src,args)
{
    //alert('DateVal');
    var dtbox=document.getElementById(src.controltovalidate);
    var finyr=src.FinYr;    
    var str=trim(dtbox.value);
    var dtparts;
    var dat,mon,yr,dat2,mon2;
    var lp_yr=false;
    var month_type;
    if(str==''){
        args.IsValid=false;
        return;}
    else
    {
        dtparts=str.split("/");
        if(dtparts.length==3){
        dat=parseInt(dtparts[0],10);
        mon=parseInt(dtparts[1],10);
        yr=dtparts[2],10;
        /*if(dat<=9 && dat.length==1)
        dat2='0'+dat;
        if(mon<=9 && mon.length==1)
        mon2='0'+mon;*/
        if(yr.length!=4)
        {
            args.IsValid=false;
            alert('Year should be in the form - YYYY');
            return;
        }
        //dtbox.value=dat2+'/'+mon2+'/'+yr; 
        if(finyr!=null && trim(finyr)!='')
        {
            var yr0=finyr.substring(0,4)
            var yr1=finyr.substring(5,9)
            if(yr==yr0)
            {
                if(parseInt(mon,10)<4)
                {
                    args.IsValid=false;
                    alert('Month not in login financial year');
                    return;
                }
            }
            else if(yr==yr1)
            {
                if(parseInt(mon,10)>3)
                {
                    args.IsValid=false;
                    alert('Month not in login financial year');
                    return;
                }
            }
            else
            {
                args.IsValid=false;
                alert('Please provide date of login financial year - '+finyr);
                return;
            }
        }
        if(parseInt(yr,10)%100==0){
          if(parseInt(yr,10)%400==0)
            lp_yr=true;}
        else{
          if(parseInt(yr,10)%4==0)
            lp_yr=true;}
        if(parseInt(mon,10)<=7){  //till July
            if(parseInt(mon,10)%2==0)
            {
                if(mon==2){     //Feb
                  if(lp_yr)
                    month_type="29"
                else
                    month_type="28"  
                }
                else
                    month_type="30"
            }
            else
                month_type="31"
        }
        else{
            if(parseInt(mon,10)%2==0)
                month_type="31"
            else
                month_type="30"
        }    
    if(parseInt(dat,10)>parseInt(month_type,10)){
        args.IsValid=false;
        alert('Month does not have this date');
        return;}
    else if(parseInt(mon,10)>12){
        args.IsValid=false;
        alert('Month is greater than 12');
        return;}
    else
        args.IsValid=true;
        return;
    }
    else
        args.IsValid=false;
        return;
    }    
    /*if(args.IsValid)
    {
        if(dat<=9 && dat.length==1)
        dat='0'+dat;
        if(mon<=9 && mon.length==1)
        mon='0'+mon;
        dtbox.value=dat+'/'+mon+'/'+yr;
    }*/
}
function HashTextOld(s,dynS) //this function requires inclusion of Encode/md5.js
{
    var salt = 'AC_@94_B69ctXu5980^F';
    if (dynS == null)
    { }
    else
    {salt = salt + dynS.value; }
    return (hex_md5(salt + s + salt));
}
function HashText(s) //this function requires inclusion of Encode/md5.js
{
    //var salt = 'AC_@94_B69ctXu5980^F';
    //if (dynS != null)
    //{ }
    //else
    
    //{ salt = salt + dynS.value; }
    return (hex_sha256(s));
}