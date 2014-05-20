// Common JScript File
//Function to Clear a drop Down Selection
var strSpecialCharacterMsg = " cannot contain special characters (&,#,?,',\",%,+ and Tab space)";

function clearSelect(select)
{
    //Set the select box's length to 1 so only "--Select--" is availale in the selection
    if(select != null)
    select.options.length = 1;	    		
}

//Function To add an intem to a DropDown List
function appendToSelect(select, strValue, strContent)
{		
    if(strValue !="")
    {
        var optn = document.createElement("OPTION");
        optn.text = strContent;
        optn.value = strValue;
	    document.getElementById(select).options.add(optn);
	}
}

//Function to round a number to decimal points
function roundNumber(num, dec)
{
    var result = Math.round(num*Math.pow(10,dec))/Math.pow(10,dec);
    return result;
}

/*------------------------------------------------------------------------
 Format a given nunber. Will keep the decimal place as it is.
 E.g. 2562332.23 -> 2,562,332.23
------------------------------------------------------------------------*/
function formatNumber(number) {

   if(number=="") {
      return "-";
   }
   
   var isNeg = false;
   if(number.charAt(0)=="-") {
      isNeg = true;
      number = number.substring(1);
   }

   //convert to string first
   number = number + "";
   var i = number.indexOf(".")-0;
   
   if(i==-1)
      i = number.length;
   
   var integer = number.substring(0, i);
   var decimal = number.substring(i, number.length);
   var x = 0;
   for(x=i-3; x>0; x=x-3) {
      var rear = integer.substring(x,integer.length);
      integer = integer.substring(0, x);
      integer = integer+","+rear;
   }
   
   if(!isNeg)
      return ""+integer+decimal;
   else
      return "-"+integer+decimal;
}

//Function for not allowing spaces
function CheckSpace()
{     
  if(event.keyCode == 32){event.keyCode = null; }  
}

String.prototype.trim = function() {
a = this.replace(/^\s+/, '');
return a.replace(/\s+$/, '');
};

function isAlphabetic(sText)
{    if(sText.trim()==""){return false;}
    var ValidChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ01234567890* ";
    var IsAlphabetic=false;
    var Char;
    for (i = 0; i < sText.length; i++)
    {
        Char = sText.charAt(i);
        if (ValidChars.indexOf(Char) >= 0)
        {
                IsAlphabetic = true;    
                break;
         }       
    }
    return IsAlphabetic; 
} 

//Function to allow only numeric values
function CheckIntegers(obj)
{ 
    var strValue;
    if(obj != null){strValue = obj.value;}
    if (event.keyCode < 48 || event.keyCode > 57 ){event.keyCode = null;}    
}

//Function to allow only numeric values
function CheckNumber(eventRef, obj)
{ 
    var keyStroke = eventRef.keyCode ? eventRef.keyCode : ((eventRef.charCode) ? eventRef.charCode : eventRef.which);
  
    var strValue;
    if(obj != null){strValue = obj.value;}
    if ((keyStroke < 48 || keyStroke > 57 ) && (keyStroke != 46)) {return false;}
    if(strValue.indexOf('.') >=0)
    {
        if(keyStroke == 46){return false; }
        if((strValue.substring(strValue.indexOf('.'),strValue.length).length) > 4){return false; }     
    }
}

//Function to allow only numeric values
/*function CheckNumber(obj, i)
{     
    var strValue;
    if(obj != null){strValue = obj.value;}
    if ((event.keyCode < 48 || event.keyCode > 57 ) && (event.keyCode != 46) && (event.keyCode != 8)) {event.keyCode = null;}
    if(strValue.indexOf('.') >=0)
    {
        if(event.keyCode == 46){event.keyCode = null; }
        if((strValue.substring(strValue.indexOf('.'),strValue.length).length) > i){event.keyCode = null; }     
    }
}*/

//Function to allow only numeric values
function CheckFreightNumber(obj)
{ 
    //alert(event.keyCode);
    var strValue;
    if(obj != null){strValue = obj.value;}
    if ((event.keyCode < 48 || event.keyCode > 57 ) && (event.keyCode != 46) ) {event.keyCode = null;}
    if(strValue.indexOf('.') >=0)
    {
        if(event.keyCode == 46){event.keyCode = null; }
        if((strValue.substring(strValue.indexOf('.'),strValue.length).length) > 2){event.keyCode = null; }     
    }
}

function validateQuantitydigit(eventRef)
{    
  var keyStroke = eventRef.keyCode ? eventRef.keyCode : ((eventRef.charCode) ? eventRef.charCode : eventRef.which);
  //alert(keyStroke);
    if(keyStroke == 45)
        return false;
}

//Function to allow only numeric values
function CheckNegativeNumber(obj,i)
{     
    var strValue;
    if(obj != null){strValue = obj.value;}    
    if(event.keyCode == 45)
    {
        if(strValue.charAt(0) == "-")
        {
           // alert("dd");
           event.keyCode = null; 
        }        
    }
    else
    {        
        if ((event.keyCode < 48 || event.keyCode > 57 )&& (event.keyCode != 46)) {event.keyCode = null;}
        if(strValue.indexOf('.') >=0)
        {
            if(event.keyCode == 46){event.keyCode = null; }
            if((strValue.substring(strValue.indexOf('.'),strValue.length).length) > i){event.keyCode = null; }     
        }
    }  
    return event.keyCode;  
}


/************Function to check Numeric value with precesion and decimal points ********************/
var sPreviousValue;	
var sCurrentValue;
function checkFieldFocus()
{    
	sPreviousValue = null;
}

function checkFieldDown(obj, i, j)
{  
    if(obj != null)
    {                        
       if(obj.value.charAt(0) == ".")
          obj.value = "0" + obj.value;                    
    }
    
    if(obj.value!="-")
    {
	    sCurrentValue = obj.value;

	    //var strRegExp = '(^-?\\d{1,' + i + '}\\.\\d{1,' + j + '}$)|(^-?\\d{1,' + i + '}$)';
	    var strRegExp = '(^-?\\d{1,' + i+ '}\\.\\d{1,' + j + '}$)|(^-?\\d{1,' + i + '}\\.$)|(^-?\\d{1,' + i + '}$)';
	    var regExp = new RegExp(strRegExp, '');
    
    
	    if(!obj.value.match(regExp))
	    {
		   
		    if(sPreviousValue != null)
		    {
		     
		     if(obj.value.indexOf(".")!=0)
			    obj.value = sPreviousValue;
			    
			}
		    else
			    obj.value = '';
	    }
	    else
		    sPreviousValue = sCurrentValue;
	}
}

function checkFieldUp(obj, i, j)
{
   if(obj != null)
    {                        
       if(obj.value.charAt(0) == ".")
          obj.value = "0" + obj.value;                    
    }
 
    if(obj.value!="-")
    {
	    var strRegExp = '(^-?\\d{1,' + i+ '}\\.\\d{1,' + j + '}$)|(^-?\\d{1,' + i + '}\\.$)|(^-?\\d{1,' + i + '}$)';
	    var regExp = new RegExp(strRegExp, '');

	    if(!obj.value.match(regExp) && obj.value != '')
	    {
		    if(sPreviousValue != null)
		    {
		        if(obj.value.indexOf(".")!=0)
			    obj.value = sPreviousValue; 			    
			 }
		    else
			    obj.value = '';
	    }
	    else
		    sPreviousValue = obj.value;
	}					
}
/**************************************************************************************************/


function changeFromUKFormat(sUK) 
	{
	   
	   var A = sUK.split(/[\\\/]/);
	   A = [A[1],A[0],A[2]]; 	   
	   return A.join('/'); 
	}

function getQuerystring(key, default_)
{
  if (default_==null) default_=""; 
  key = key.replace(/[\[]/,"\\\[").replace(/[\]]/,"\\\]");
  var regex = new RegExp("[\\?&]"+key+"=([^&#]*)");
  var qs = regex.exec(window.location.href);
  if(qs == null)
    return default_;
  else
    return qs[1];
}

function setSelectedIndex(s, v) {
    for ( var i = 0; i < s.options.length; i++ ) {        
        if ( s.options[i].value == v ) {            
            s.options[i].selected = true;
           // return;
        }
    }
}

function parseDate(str) { 
    var date = str.split('/'); 
    return new Date(date[2], date[0] - 1, date[1]); 
} 

//==================  diffWithTwoDate(STRING s,STRING s)=======================================
// function -- return diff between passed in date and system date
// inTermOf -> 1 - sec
//             2 - min
//             3 - hr
//             4 - day
//             5 - yr
//-----------------------------------------------------------------------------

/*
function diffWithTwoDate(strDate1, strDate2, inTermOf){
   var timeA = new Date(); 
   timeA.setMonth(mparseInt(strDate1.substring(3,5))-1,mparseInt(strDate1.substring(0,2)));
   timeA.setYear(mparseInt(strDate1.substring(6,10)));
   timeB = new Date();
   timeB.setMonth(mparseInt(strDate2.substring(3,5))-1,mparseInt(strDate2.substring(0,2)));
   timeB.setYear(mparseInt(strDate2.substring(6,10)));
   timeDifference = timeB - timeA;
   count =1;
   if (inTermOf == 1)
      count = 1 * 1000;
   else if (inTermOf == 2)
      count = 1 * 1000 * 60;
   else if (inTermOf == 3)
      count = 1 * 1000 * 60 *60;
   else if (inTermOf == 4)
      count = 1 * 1000 * 60 * 60 * 24;
   else if (inTermOf == 5)
      count = 1 * 1000 * 60 * 60 * 24 * 365;
   return timeDifference/count;
}*/

//Modified for VAG12SR0002 
function diffWithTwoDate(strDate1, strDate2, inTermOf){
   var timeA = new Date(); 
   var strDate1Array = strDate1.split("/"); 
   timeA.setMonth(mparseInt(strDate1Array[1])-1,mparseInt(strDate1Array[0]));
   timeA.setYear(mparseInt(strDate1Array[2]));
   
   timeB = new Date();
   var strDate2Array = strDate2.split("/");
   timeB.setMonth(mparseInt(strDate2Array[1])-1,mparseInt(strDate2Array[0]));
   timeB.setYear(mparseInt(strDate2Array[2]));
   timeDifference = timeB - timeA;
   count =1;
   if (inTermOf == 1)
      count = 1 * 1000;
   else if (inTermOf == 2)
      count = 1 * 1000 * 60;
   else if (inTermOf == 3)
      count = 1 * 1000 * 60 *60;
   else if (inTermOf == 4)
      count = 1 * 1000 * 60 * 60 * 24;
   else if (inTermOf == 5)
      count = 1 * 1000 * 60 * 60 * 24 * 365;
   return timeDifference/count;
}


//==================10)  mparseInt(s)====== ===================================
// Function -- return interger value of the number
// modification of parseInt function as parseInt might not return a valid
// value if the string is prefix will 0
//-------------------------------------------------------------------------
function mparseInt(s){
	for (c=0;c<s.length ;c++ )
	{
		if (s.charAt(c)!='0')
		{
			break;
		}
	}
	if (c==s.length) return 0;
	return parseInt(s.substring(c, s.length)); 
}


function GetDaysBetweenDates(date1, date2) {     
    return (date2 - date1) / (1000 * 60 * 60 * 24) 
}


/*Check for a special character'***/
function isSplChar(str)
{ 
    var i;
	var s = str;
    
    if(isContainSpacesOrTab(str))
    {return true;}
    
    if(str !="")
    {
        
        strNumExpression = /^[a-zA-Z0-9\t\~\`\!\@\$\^\*\(\)\-\_\=\{\}\:\;\<\>\,\.\/\|\[\]\<\>\s\\]+$/;            
        //strNumExpression = /^[a-zA-Z0-9\t\~\`\!\@\$\^\*\(\)\-\_\=\{\}\:\;\>\,\.\/\|\[\]\>\s\\]+$/;
        
	    for(i = 0; i < s.length; i++)
	    {
		    var x = s.charAt(i);
		    if((s).match(strNumExpression)){			    
				    return false;			    
		    }
		    else{
			    return true;
		    }
	    }
	}	
	return false;
}

//Function to validate Tab Space and space
function isContainSpacesOrTab(val)
{
      if(val==null){return false;}
      if(val.length==0) {return false;}
      for(var i=0;i<val.length;i++) {
            if ((val.charAt(i)=="+") || (val.charAt(i)=="\t")) {return true;}
      }
      return false;     
}


function hasWhiteSpace(s) 
{
    if(s !="")
    {
        if (s.indexOf(' ') != -1)
           return true;
        else
           return false;
    }
    else
           return false;
}

function show(layer_ref) 
{ 
    state = 'block';          
    if (document.all) { //IS IE 4 or 5 (or 6 beta)
        eval( "document.all." + layer_ref + ".style.display = state");
    }
    if (document.layers) { //IS NETSCAPE 4 or below
        document.layers[layer_ref].display = state;
    }
    if (document.getElementById &&!document.all) {
        hza = document.getElementById(layer_ref);
        hza.style.display = state;
    }
}
  
function hide(layer_ref) { 
    state = 'none';  
    if (document.all) { //IS IE 4 or 5 (or 6 beta)
        eval( "document.all." + layer_ref + ".style.display = state");
    }
    if (document.layers) { //IS NETSCAPE 4 or below
        document.layers[layer_ref].display = state;
    }
    if (document.getElementById &&!document.all) {
        hza = document.getElementById(layer_ref);
        hza.style.display = state;
    }
}

function showOnlyInfo (divref, obj)  
{
	hide(divref+"error");
	show (divref+"info");		
}

function checkForEmpty (divref, obj)  {
	hide(divref+"info");
	if (obj.value == "") {
		show (divref+"error");
	}			
}


function IsValidEmail(sValue)
{
    //var emailPat = /^(\".*\"|[A-Za-z]\w*)@(\[\d{1,3}(\.\d{1,3}){3}]|[A-Za-z]\w*(\.[A-Za-z]\w*)+)$/;
    var emailPat = /^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,6}|[0-9]{1,3})(\]?)$/;
    //var emailPat = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\ ".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA -Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    var matchArray = sValue.match(emailPat);
     if (matchArray == null)
     {
           return false;
     }
     return true;
}

function CheckMultiLineTextBoxLength(obj)
{
    if(obj != null)
    {                        
        if(obj.value.length > 254)
        {            
            event.keyCode = null;
        }
    }
}


//Function for Date Validation

var dtCh= "/";
var minYear=1900;
var maxYear=2100;

function isInteger(s){
	var i;
    for (i = 0; i < s.length; i++){   
        // Check that current character is number.
        var c = s.charAt(i);
        if (((c < "0") || (c > "9"))) return false;
    }
    // All characters are numbers.
    return true;
}

function isValidLen(s,l)
{
    var nums="0123456789";
	var j =0;	
	var bReturn= true;
	for (var i = 0; i < s.length; i++)
	{   
        // Check that current character is number.        
        if (nums.indexOf(s.charAt(i))>=0)
        {j++;}        
    }
    if(j >=l)
        bReturn= true;
    else
        bReturn = false;    
        
    if(bReturn)
    {    
        if(isValidChars(s,"[0-9$-]"))
        {bReturn = true;}
        else {bReturn = false;} 
    }
    return bReturn;   
}

function isValidLen(s,l,k)
{
    var nums="0123456789";
	var j =0;	
	var bReturn= true;
	for (var i = 0; i < s.length; i++)
	{   
        // Check that current character is number.        
        if (nums.indexOf(s.charAt(i))>=0)
        {j++;}        
    }
    if((j ==l) || (j ==k))
        bReturn= true;
    else
        bReturn = false;    
        
   if(bReturn)
    {    
        if(isValidChars(s,"[0-9$-]"))
        {bReturn = true;}
        else {bReturn = false;} 
    }
    return bReturn;   
}


function clearDropDown(ddlctrl) 
{   
var theDropDown = ddlctrl;   
var numberOfOptions = theDropDown.options.length;
for (i=0; i<numberOfOptions; i++) {   
 //Note: Always remove(0) and NOT remove(i)   
 theDropDown.remove(0);
}   
} 



function stripCharsInBag(s, bag){
	var i;
    var returnString = "";
    // Search through string's characters one by one.
    // If character is not in bag, append to returnString.
    for (i = 0; i < s.length; i++){   
        var c = s.charAt(i);
        if (bag.indexOf(c) == -1) returnString += c;
    }
    return returnString;
}

function daysInFebruary (year){
	// February has 29 days in any year evenly divisible by four,
    // EXCEPT for centurial years which are not also divisible by 400.
    return (((year % 4 == 0) && ( (!(year % 100 == 0)) || (year % 400 == 0))) ? 29 : 28 );
}
function DaysArray(n) {
	for (var i = 1; i <= n; i++) {
		this[i] = 31
		if (i==4 || i==6 || i==9 || i==11) {this[i] = 30}
		if (i==2) {this[i] = 29}
   } 
   return this
}

function isDate(dtStr){
	var daysInMonth = DaysArray(12)
	var pos1=dtStr.indexOf(dtCh)
	var pos2=dtStr.indexOf(dtCh,pos1+1)
	var strDay=dtStr.substring(0,pos1)
	var strMonth=dtStr.substring(pos1+1,pos2)
	var strYear=dtStr.substring(pos2+1)
	strYr=strYear
	if (strDay.charAt(0)=="0" && strDay.length>1) strDay=strDay.substring(1)
	if (strMonth.charAt(0)=="0" && strMonth.length>1) strMonth=strMonth.substring(1)
	for (var i = 1; i <= 3; i++) {
		if (strYr.charAt(0)=="0" && strYr.length>1) strYr=strYr.substring(1)
	}
	month=parseInt(strMonth)
	day=parseInt(strDay)
	year=parseInt(strYr)
	if (pos1==-1 || pos2==-1){
		//alert("The date format should be : dd/mm/yyyy")
		return false
	}
	if (strMonth.length<1 || month<1 || month>12){
		//alert("Please enter a valid month")
		return false
	}
	if (strDay.length<1 || day<1 || day>31 || (month==2 && day>daysInFebruary(year)) || day > daysInMonth[month]){
		//alert("Please enter a valid day")
		return false
	}
	if (strYear.length != 4 || year==0 || year<minYear || year>maxYear){
		//alert("Please enter a valid 4 digit year between "+minYear+" and "+maxYear)
		return false
	}
	if (dtStr.indexOf(dtCh,pos2+1)!=-1 || isInteger(stripCharsInBag(dtStr, dtCh))==false){
		//alert("Please enter a valid date")
		return false
	}
return true
}

function ValidateForm(){
	var dt=document.frmSample.txtDate
	if (isDate(dt.value)==false){
		dt.focus()
		return false
	}
    return true
 }
 
 
 
 /************************Function used for multiplying two large numbers*************************/
 /**************this has some junk code which can be removed later on ***********************/
    var Base = 10000;          // The number base 
var mess="<br>";
 
function remTrailingZeros(x) {
var decPos=x.indexOf(".")
if (decPos>-1)
{
first=x.substring(0,decPos);
second=x.substring(decPos,x.length);
while (second.charAt(second.length-1)=="0")
second=second.substring(0,second.length-1);
if (second.length>1)
return first+second;
else
return first;
}
return x;
}//end of  remTrailingZeros(x)
//used to find the number of digits in the base
function getLength(num) {
return Math.ceil(Math.log(num)/Math.LN10);
}//end of  getLength(num)
 
function signSwap(x) {
if (x=="+")
x="-";
else
x="+";
return x;
}//end of  signSwap(x)
 
 
function removeCommas(aNum) {
//remove any commas
aNum=aNum.replace(/,/g,"");
//remove any spaces
aNum=aNum.replace(/\s/g,"");
return aNum;
}//end of  removeCommas(aNum)
 
//This checknum is for multiplying
function checkNumMult(aNum) {
var isOK=0;
var aNum=aNum+"";
//if the number has one or none decimal points, lastIndexOf and indexOf
//will give the same answer
if (aNum.lastIndexOf(".")!=aNum.indexOf("."))
isOK=1;
else
//here a regular expression is used to check for numbers and decimals
if (aNum.match(/[^0-9.]/g))
isOK=2;
return isOK;
 
}//end of  checkNumMult(aNum)
 
 
 
//add commas separating thousands
function addseps(x) {
//make x a new variable
var x=x;
//make x a string
x+="";
//or x=String(x);
//iLen is the number of digits before any decimal point
// for 45.123, iLen is 2
//iLen is the length of the number, if no decimals
iLen=x.length;
pos=x.indexOf(".");
if (pos>-1) //there are decimals
{
iLen=pos;
}
//add the decimal point
temp="";
//add the decimal part to begin
// with 45.123, we add the .123
temp=x.substring(iLen,x.length);
//iLen-1 is the rightmost non-decimal digit (5 in 98745.123)
for (var i=iLen-1;i>=0;i--)
//we add a separator when the expression (iLen-i-1)%3==0 is true...
//except when i is (iLen-1), or the first digit
//eg (98745.12). i is iLen-1, and the digit pos is next the decimal, 
//it is 5. From here, we decrement i...iLen-2, iLen-3, iLen-4 ... when i is a multiple of
//3, (i=iLen-iLen+4-1). This point is just before the number 7
if ((iLen-i-1)%3==0&&i!=iLen-1)
temp=x.charAt(i)+","+temp;
else
temp=x.charAt(i)+temp;
return temp;
}//end of  addseps(x)
 
 
//inserts the decimal point 
//as we cannot insert into a javascript string
//we need to re-write it, putting the decimal point in
//at the right place
function insertDec(num,decPlace) {
var num=num;
var decPlace=decPlace;
ans="";
mess+="num="+num+"; decPlace="+decPlace+"<br>";
if (decPlace>0)
{
ans=num.substring(0,num.length-decPlace)+"."+
	num.substring(num.length-decPlace,num.length);
return ans;
}
else
return num;
}//end of  insertDec(x,decPlace)
//find decimal point position
function getDec(x) {
var x=x;
x=x+"";
//position of first decimal digit
pos=x.indexOf('.')+1;
//if 0, then no decimals (-1+1)
if (pos>0)
return x.length-pos;
else
return 0;
}//end of  getDec(x)
 
function myRand() {
z="";
s="";
a=Math.random()* Math.pow(10,18);
b=Math.random()* Math.pow(10,18);
z=String(a)+String(b);
decPoint=Math.floor(Math.random()*Math.floor(z.length));
z=z.substring(0,decPoint)+"."+z.substring(decPoint,z.length);
if (decPoint==0)
z="0"+z;
return z;
}//end of  myRand()
 
function checkAns(x,y,ans) {
ok= ((digSum(x)*digSum(y))%9==digSum(ans)%9);
ok+=ans.length<=x.length+y.length;
if (ok)
return true
else
return false;
 
}//end of  checkAns(x,y,ans)
 
function digSum(num) {
sum=0;
for (i=0;i<num.length;i++)
sum+=Number(num.charAt(i));
return sum%9;
}//end of  digSum(num)
 
function isNum(x) {
nums="0123456789";
for (i=0;i<x.length;i++)
{
if (nums.indexOf(x.charAt(i))==-1)
return false;
}
}//end of  isNum()
 
function Mul(n1,n2) {

t1=new Date(); //used to calculate start time
aX=new Array(); //holds number x
aY=new Array(); //holds number y
aW=new Array(); //holds the product, x*y
//n1=removeCommas(n1); //clean up n1 and n2
//n2=removeCommas(n2);
x=n1; //set x and y values
y=n2;
 
s="";
 
if (!((checkNumMult(x)==0)&&(checkNumMult(y)==0)))
{
}//end number problem
else //number checks out
{
numlen=x.length+y.length;
decXo=getDec(x);
decYo=getDec(y);
decX=decXo;
decY=decYo;
 
str="";
//remove decimal from x
x=x.replace(".","");
//remove decimal from y
y=y.replace(".","");
//initialise decPlace, which is the number of decimals in 
//the number with the most decimals
//First just assume x is the number with most decimal places
//If decX isn't longer than decY, then the following will be true
var decPlace=decX;
//Then check which is the correct number
if (decX>decY)
{
decPlace=decX;
//add zeros to y
//the number of zeros is just the difference between the number of
//decimal places in each number.
//decYo is the number of decimals in the original y number.
for (var i=0;i<(decPlace-decYo);i++)
{
//add a zero at the end
y+="0";
//increment decY, so we keep a record of the decimal position
//in the new number. For instance
// if decYo=2, as in 1.12, then the number is really 112/10^2
//When we add zeros, the position becomes one more
//for each zero we add .. 1.120, decimal is now 3 from the end, or
//the number is really 1120/10^3
//increment decY
decY+=1;
}
 
}
//add zeros to x, if y has more decimals
//repeat of the above
else
if (decY>decX)
{
decPlace=decY;
//add zeros to x
for (var i=0;i<(decPlace-decXo);i++)
{
x+="0";
decX+=1;
}
}
//otherwise, decPlace is as above
//swap
//find the length of the numbers, so we can put them in the right
//order for the calculation
xlen=x.length;
ylen=y.length;
cellSize=getLength(Base);
maxSize=Math.ceil(getLength(x)/cellSize)+Math.ceil(getLength(y)/cellSize);
//the length of the array (sum of all digits)
sumDig=x.length+y.length;
slice=Math.ceil(sumDig/cellSize);
//make an array:
for (i=0;i<=slice;i++)
aX[i]=null; //this avoids lots of zeros in the answer
for (i=0;i<=slice;i++)
aY[i]=null; 
for (i=0;i<=2*slice;i++)
aW[i]=null; 
//slice is the number of itesm in the array. Each item or cell has cellSize digits
//put the number into the array
for (i=0;i<slice;i++)
{
//we need to fill the array with the right-most numbers at the right of the array
aX[slice-i-1]=(x.substring(x.length-cellSize*(i+1),x.length- cellSize*(i)));
aY[slice-i-1]=(y.substring(y.length-cellSize*(i+1),y.length- cellSize*(i)));
}
 
//carry is zero at the start
  carry=0;
//n is the length of the array
  for (i=slice-1; i>=0; i--) {    
  //multiply numbers
  for (j=slice-1;j>=0;j--)
  {
    prod= aX[i]*aY[j];		
    //add any carry from previous
    prod += carry;	
    //deal with any carry
    if (prod>=Base) {
      carry =Math.floor( prod/Base);
      prod -= (carry*Base);
    }
    else 
      carry = 0;
      //some of the cells make a zero which we don't want in the answer
      //We keep the nulls, null
     // if (prod!=0)
    aW[i+j]+= prod;
    if (aW[i+j]>=Base)
    {
    rem=Math.floor(aW[i+j]/Base)
    aW[i+j]-=rem*Base;
    carry+=rem;
    }
   if (aW[i+j]>Base)
    {
    aW[i+j-1]+=Math.floor(aW[i+j]/Base);
    aW[i+j]=aW[i+j]%Base;
    } 
    }//end of for j
}//end of for i
//write answer
z="";
 
for (k=0;k<aW.length;k++)
if (aW[k]!=null) //we kept the nulls!
{
if (
	(
	(aW[k]+"").length==cellSize)||	
	(k>aW.length-2)
   )
z+=((aW[k]));
else
{
while ((aW[k]+"").length<cellSize)
{
aW[k]='0'+aW[k];
} 
z+=((aW[k]));
}
}
//put the decimals back in the numbers
decZ=decX+decY;
//now write out the answer:
x=insertDec(x,decX);
y=insertDec(y,decY);
x=addseps(x);
y=addseps(y);
//remove leading zeros from answer:
while (z.charAt(0)=="0")
{
z=z.substring(1,z.length);
}
if (z.charAt(0)==".")
z="0"+z;
t2=new Date();
t1=(t2.getTime()-t1.getTime())/1000
z=insertDec(z,decZ);

return z 
//alert(z);
//z=addseps(z);

//z=remTrailingZeros(z);
 //alert(Mul('999999999999999','99999999999'));
   }//else number checks
}

//Adding two large Numbers

function addseps(x) {
//make x a new variable
var x=x;
//make x a string
x+="";
//or x=String(x);
//iLen is the number of digits before any decimal point
// for 45.123, iLen is 2
//iLen is the length of the number, if no decimals
iLen=x.length;
pos=x.indexOf(".");
if (pos>-1) //there are decimals
{
iLen=pos;
}
//add the decimal point
temp="";
//add the decimal part to begin
// with 45.123, we add the .123
temp=x.substring(iLen,x.length);
//iLen-1 is the rightmost non-decimal digit (5 in 98745.123)
for (var i=iLen-1;i>=0;i--)
//we add a separator when the expression (iLen-i-1)%3==0 is true...
//except when i is (iLen-1), or the first digit
//eg (98745.12). i is iLen-1, and the digit pos is next the decimal, 
//it is 5. From here, we decrement i...iLen-2, iLen-3, iLen-4 ... when i is a multiple of
//3, (i=iLen-iLen+4-1). This point is just before the number 7
if ((iLen-i-1)%3==0&&i!=iLen-1)
temp=x.charAt(i)+","+temp;
else
temp=x.charAt(i)+temp;
return temp;
}//end of addseps(x)


function insertDec(num,decPlace) {
var num=num;
var decPlace=decPlace;
ans="";
if (decPlace>0)
{
for (var i=0;i<num.length;i++)
{
//when we get to the position we want to 
//insert the decimal point, we add the point to
//our string
//decPlace is the number of decimal digits in the original, from getDec(x)
//remember the return value of this function was return x.length-pos;
if (i==num.length-decPlace)
ans=ans+"."+num.charAt(i);
else
ans=ans+num.charAt(i);
}
return ans;
}
else
return num;
}//end of insertDec(x,decPlace)


function getDec(x) {
x=x+"";
//position of first decimal digit
pos=x.indexOf('.')+1;
//if 0, then no decimals (-1+1)
if (pos>0)
return x.length-pos;
else
return 0;
}//end of getDec(x)


function removeCommas(aNum) {
//remove any commas
aNum=aNum.replace(/,/g,"");
//remove any spaces
aNum=aNum.replace(/\s/g,"");
return aNum;
}//end of removeCommas(aNum)

function checkNum(aNum) {
var isOK=0;
var aNum=aNum+"";
//if the number has one or none decimal points, lastIndexOf and indexOf
//will give the same answer
if (aNum.lastIndexOf(".")!=aNum.indexOf("."))
isOK=1;
else
//here a regular expression is used to check for numbers and decimals
if (aNum.match(/[^0-9.]/))
isOK=2;
return isOK;
}//end of checkNum(aNum)



function addEm(x,y) {
var x=x;
var y=y;
//sum used for javascript
x=removeCommas(x);
y=removeCommas(y);
if (!((checkNum(x)==0)&&(checkNum(y)==0)))
{

if (checkNum(x)>0)
{

switch (checkNum(x)) {
case 1:
//alert("Too many decimal points in number 1.")
break    
case 2:  
//alert("Some characters aren't numbers in number 1");  
break       

}//end of switch 

}//end of check number 1

if (checkNum(y)>0)
{

switch (checkNum(y)) {
case 1:
//alert("Too many decimal points in number 2.")
break    
case 2:  
//alert("Some characters aren't numbers in number 2");  
break       

}//end of switch 

}//end of check number 1

}//end number problem
else //number checks out
{

jssum=Number(x)+Number(y);
decXo=getDec(x);
decYo=getDec(y);
decX=decXo;
decY=decYo;

str="";
//remove decimal from x
x=x.replace(".","");
//remove decimal from y
y=y.replace(".","");

//initialise decPlace, which is the number of decimals in 
//the number with the most decimals
//First just assume x is the number with most decimal places
//We are just declaring the variable, so any number could be used.
var decPlace=decX;
//Then check which is the correct number
if (decX>decY)
{
decPlace=decX;
//add zeros to y
//the number of zeros is just the difference between the number of
//decimal places in each number.
//decYo is the number of decimals in the original y number.
for (var i=0;i<(decPlace-decYo);i++)
{
//add a zero at the end
y+="0";
//increment decY, so we keep a record of the decimal position
//in the new number. For instance
// if decYo=2, as in 112, then the number is really 112/10^2
//When we add zeros, the position becomes one more
//for each zero we add .. 1120, decimal is now 3 from the end, or
//the number is really 1120/10^3
decY+=1;
}

}
//add zeros to x, if y has more decimals
//repeat of the above
else
if (decY>decX)
{
decPlace=decY;
//add zeros to x
for (var i=0;i<(decPlace-decXo);i++)
{
x+="0";
decX+=1;
}
}


//swap
//find the length of the numbers, so we can put them in the right
//order for the calculation
xlen=x.length;
ylen=y.length;
//swap the numbers, if xlen isn't the longest
if (xlen<ylen)
{
//swap values
var temp=y;
y=x;
x=temp;
temp=decX;
decX=decY;
decY=temp;
//new lengths, if x is shorter
//could have just swapped them as above!
xlen=x.length;
ylen=y.length;
}
//end of swapping

//begin adding
//set carry to zero.
var carry=0;
//set the string, s, which will contain the answer
var s="";
//now add the two numbers:
//work down from the length of the longest string:
//which is always x
var numx,numy;
for (var i=xlen-1;i>=0;i--)
{
//only add the y numbers, if there are any left, else we add zero
numy=0;
if ((ylen-xlen+i)>-1)
numy=parseInt(y.charAt(ylen-xlen+i));
//In the above, when ylen-xlen+i=0, we are at the end of the y numbers
//and i=xlen-ylen. For the next i, (i-1), we will be beyond the length of y, and 
//so just add a possible carry, and thereafter, just zeros

//x is always found in the longest string
numx=parseInt(x.charAt(i));
//add the sum of the numbers and any carry from previously
//we add only the units bit of the number
//10 is the normal base for decimals
s=(numy+numx+carry)%10+s;
//we carry the tens bit of the new number
carry=Math.floor((numy+numx+carry)/10);

}//end of adding

if (carry>0)
s=carry+s;
/*
at the end of the first number, x, we might still have something to carry
For instance, 9+9 gives 8, plus a FINAL carry of 1 (in a new place)

  9+
  9=
18
But:
 18+
   9
 27
... has a normal carry one place from the end, but no carry at the end
so we add any carry on the front of the string
*/

//put the decimals back in the numbers
s=insertDec(s,decPlace);
//now write out the answer:
x=insertDec(x,decX);
y=insertDec(y,decY);
x=addseps(x);
y=addseps(y);
//once again check the lengths of the two numbers. 
//swap numbers
//find the length of the numbers, so we can put them in the right
//order for the calculation
xlen=x.length;
ylen=y.length;
//swap the numbers, if xlen isn't the longest
if (xlen<ylen)
{
//swap values
var temp=y;
y=x;
x=temp;
temp=decX;
decX=decY;
decY=temp;
//new lengths, if x is shorter
//could have just swapped them as above!
xlen=x.length;
ylen=y.length;
}
//end of swapping

//align the numbers by putting a space infront of the shortest number
for (var i=0;i<(xlen-ylen);i++)
y="&nbsp;"+y;

//the answer string s, can only be one more longer than the x string
//but we will write general code anyway
//note, we cannot use y or ylen anymore because y contains "&nbsp;
//which is 6 characters, creating one space!
//s=addseps(s);
var slen=s.length;
for (var i=0;i<(slen-xlen);i++)
{
x="&nbsp;"+x;
y="&nbsp;"+y;
}

return s;
//document.getElementById("s1").innerHTML=(x)+"+<br><u>"+(y)+"</u>=<br>"+s+"<br>Javascript calculates: <br>"+jssum+"<br>";
}//end of else (numCheck OK)
}//end of  addEm(x,y)



//Substracting two large numbers
var s="";
var mess="";

//rough check of the answer
function checkAnsSub(x,y,ans) {
ok=false;
//use casting out nines
a=Number(digSum(x))-Number(digSum(y));
b=digSum(ans);
//these should be the same, but sometimes a zero is left after casting out nines
//and sometimes not. Also, a negative answer needs to have a 9 added
//if negative or zero, add 9
if (a<=0)
a+=9;
a=a%9;
//if y is bigger, then the answer is negative. We take y from x and call it negative
//the check needs to be subtracted from 9
if (Number(x)<Number(y))
//this won't work when the numbers are the same within the range of javascript
//because they appear equal
// however, we fix this later.
{
a=9-a;
}
//cast out any remaining nines
a=a%9;
//mess+=("a="+a+"; digSum x="+digSum(x)+"; digSum y="+digSum(y)+"; digSum ans="+b);
//now we can do our check
if (a	==b)
ok=true;
if (ok)
return true
else
return false;

}//end of  checkAns(x,y,ans)

//add the digits to get the digital sum for casting out nines
function digSum(num) {
//just make sure the number is a string and doesn't have a minus sign
num=String(num);
num.replace(/-/,"");
//mess+="num="+num+"<br>";
//sum is the sum of the digits
sum=0;
for (i=0;i<num.length;i++)
{
//if there is a decimal, we just ignore it
if (num.charAt(i)==".")
continue
else
sum+=Number(num.charAt(i));
//mess+="charAt"+i+"="+num.charAt(i)+"; sum="+sum+"<br>";
}
//cast out nines
return sum%9;
}//end of  checkAns(x,y,ans)

//used for checking and putting a number in at random
function myRand() {
z="";
s="";
//generate a random number and remove the decimals
//random numbers are between 0 and 1
a=Math.random()* Math.pow(10,16);
b=Math.random()* Math.pow(10,16);
a=String(a).replace(/\./g,"");
b=String(b).replace(/\./g,"");
//join the two strings together
z=String(a)+String(b);
decPoint=Math.floor(Math.random()*Number(z.length));
z=z.substring(0,decPoint)+"."+z.substring(decPoint,z.length);
if (decPoint==0)
z="0"+z;
return z;
}//end of  myRand()

//change sign
function signSwap(x) {
if (x=="+")
x="-";
else
x="+";
return x;
}//end of  signSwap(x)

//if there are any comma separators in the number entered,
//they are removed

function removeCommas(aNum) {
//remove any commas
aNum=aNum.replace(/,/g,"");
//remove any spaces
aNum=aNum.replace(/\s/g,"");
return aNum;
}//end of  removeCommas(aNum)

//this checks whether the number entered does not have several decimals
//or non-numeric characters
function checkNum(aNum) {
var isOK=0;
var aNum=aNum+"";
//if the number has one or none decimal points, lastIndexOf and indexOf
//will give the same answer
if (aNum.lastIndexOf(".")!=aNum.indexOf("."))
isOK=1;
else
//here a regular expression is used to check for numbers and decimals
if (aNum.match(/[^0-9.]/))
isOK=2;
return isOK;
}//end of  checkNum(aNum)

//add commas separating thousands
function addseps(x) {
//make x a new variable
var x=x;
//make x a string
x+="";
//or x=String(x);
//iLen is the number of digits before any decimal point
// for 45.123, iLen is 2
//iLen is the length of the number, if no decimals
iLen=x.length;
pos=x.indexOf(".");
if (pos>-1) //there are decimals
{
iLen=pos;
}
//add the decimal point
temp="";
//add the decimal part to begin
// with 45.123, we add the .123
temp=x.substring(iLen,x.length);
//iLen-1 is the rightmost non-decimal digit (5 in 98745.123)
for (var i=iLen-1;i>=0;i--)
//we add a separator when the expression (iLen-i-1)%3==0 is true...
//except when i is (iLen-1), or the first digit
//eg (98745.12). i is iLen-1, and the digit pos is next the decimal, 
//it is 5. From here, we decrement i...iLen-2, iLen-3, iLen-4 ... when i is a multiple of
//3, (i=iLen-iLen+4-1). This point is just before the number 7
if ((iLen-i-1)%3==0&&i!=iLen-1)
temp=x.charAt(i)+","+temp;
else
temp=x.charAt(i)+temp;
return temp;
}//end of  addseps(x)


//inserts the decimal point 
//as we cannot insert into a javascript string
//we need to re-write it, putting the decimal point in
//at the right place
function insertDec(num,decPlace) {
var num=num;
var decPlace=decPlace;
ans="";
if (decPlace>0)
{
for (var i=0;i<num.length;i++)
{
//when we get to the position we want to 
//insert the decimal point, we add the point to
//our string
if (i==num.length-decPlace)
ans=ans+"."+num.charAt(i);
else
ans=ans+num.charAt(i);
}
return ans;
}
else
return num;
}//end of  insertDec(x,decPlace)

//find decimal point position
function getDec(x) {
var x=x;
x=x+"";

//position of first decimal digit
pos=x.indexOf('.')+1;
//if 0, then no decimals (-1+1)
if (pos>0)
return x.length-pos;
else
return 0;
}//end of  getDec(x)


function Sub(x,y) {
var x=x;
var y=y;
var x0=removeCommas(x);;
var y0=removeCommas(y);
var sign="+";
//sum used for javascript
x=removeCommas(x);
y=removeCommas(y);
if (!((checkNum(x)==0)&&(checkNum(y)==0)))
{

if (checkNum(x)>0)
{

switch (checkNum(x)) {
case 1:
alert("Too many decimal points in number 1.")
break    
case 2:  
alert("Some characters aren't numbers in number 1");  
break       

}//end of switch 

}//end of check number 1

if (checkNum(y)>0)
{

switch (checkNum(y)) {
case 1:
alert("Too many decimal points in number 2.")
break    
case 2:  
alert("Some characters aren't numbers in number 2");  
break       

}//end of switch 

}//end of check number 1

}//end number problem
else //numbers check out
{

jssum=Number(x)-Number(y);
//decXo, and decYo are the orignal decimal positions
//as zeros are added to the numbers, the decimal position will change
decXo=getDec(x);
decYo=getDec(y);
decX=decXo;
decY=decYo;

str="";
//remove any decimal from x
x=x.replace(".","");
//remove any decimal from y
y=y.replace(".","");

//initialise decPlace, which is the number of decimals in 
//the number with the most decimals
//First just assume x is the number with most decimal places
//If decX isn't longer than decY, then the following will be true
var decPlace=decX;
//Then check which is the correct number
if (decX>decY)
{
decPlace=decX;
//add zeros to y
//the number of zeros is just the difference between the number of
//decimal places in each number.
//decYo is the number of decimals in the original y number.
for (var i=0;i<(decPlace-decYo);i++)
{
//add a zero at the end
y+="0";
decY+=1;
//increment decY, so we keep a record of the decimal position
//in the new number. For instance
// if decYo=2, as in 1.12, then the number is really 112/10^2
//When we add zeros, the position becomes one more
//for each zero we add .. 1.120, decimal is now 3 from the end, or
//the number is really 1120/10^3

}

}
//add zeros to x, if y has more decimals
//repeat of the above
else
if (decY>decX)
{
decPlace=decY;
//add zeros to x
for (var i=0;i<(decPlace-decXo);i++)
{
x+="0";
decX+=1;
}
}
//otherwise, decPlace is as above

//swap
//find the length of the numbers, so we can put them in the right
//order for the calculation
xlen=x.length;
ylen=y.length;
//swap the numbers, if xlen isn't the longest
if ((xlen<ylen)||(Number(x)<Number(y)))
{
//sign is used in the answer
sign=signSwap(sign);
//swap values
var temp=y;
y=x;
x=temp;
//swap decimal positions
temp=decX;
decX=decY;
decY=temp;
//new lengths, if x is shorter
//could have just swapped them as above!
xlen=x.length;
ylen=y.length;
}
//end of swapping

//begin subtracting
//set carry to zero.
var carry=0;
//set the string, s, which will contain the answer
var s="";
//now add the two numbers:
//work down from the length of the longest string:
//which is always x
var numx,numy;
for (var i=xlen-1;i>=0;i--)
{
numy=0;
if ((ylen-xlen+i)>-1)
numy=Number(y.charAt(ylen-xlen+i));
//In the above, when ylen-xlen+i=0, we are at the end of the y numbers
//and i=xlen-ylen. For the next i, (i-1), we will be beyond the length of y, and 
//so just add a possible carry, and thereafter, just zeros

//x is always found in the longest string
numx=Number(x.charAt(i));
//add the sum of the numbers and any carry from previously
//we add only the units bit of the number
//10 is the normal base for decimals
if (numx<(numy+carry))
{
numx+=10;
carry1=1;
}
else
carry1=0;
s=(numx-(numy+carry))%10+s;
if (carry1>0)
carry=carry1;
else
carry=0;
//we carry the tens bit of the new number
//carry=Math.floor((numy+numx+carry)/10);
if (s.length>x.length)
{


}
}//end of subtracting
//put the decimals back in the numbers
s=insertDec(s,decPlace);

//now write out the answer:
x=insertDec(x,decX);
y=insertDec(y,decY);
x=addseps(x);
y=addseps(y);

//find the length of the numbers, so we can put them in the right
//order for the calculation
xlen=x.length;
ylen=y.length;
//swap the numbers, if xlen isn't the longest
if (xlen<ylen)
{
sign=signSwap(sign);
//swap values
var temp=y;
y=x;
x=temp;
//swap decimal positions
temp=decX;
decX=decY;
decY=temp;
//new lengths, if x is shorter
//could have just swapped them as above!
xlen=x.length;
ylen=y.length;
}
//end of swapping

// check answer
//mess+="x0="+x0+"; y0="+y0+"; s="+s+"<br>";
aCheck=''
if (checkAnsSub(x0,y0,s))
aCheck="<br>"+"Ans check OK<br>";
else
{
//this is assumed to be when the numbers are so
//similar that javascript can't tell which is the bigger 
//number. As the answer check fails, we assume
//the numbers should be the other way round.
//we work out the answer again, and put it in s2
// we compute the base 10 complement of the 
//number. 
sign=signSwap(sign);
s2=""
for (i=0;i<s.length;i++) {
if (s.charAt(i)==".")
{
s2+=".";
continue;
}
if (i==s.length-1)
s2+=10-Number(s.charAt(i));
else
s2+=9-Number(s.charAt(i));
}//end of for statement
s=s2;
//swap x and y
temp=y;
y=x;
x=temp;
//we give up on checking and honestly say we haven't 
//checked the number. 
aCheck="<br>Answer has not been checked<br>";
}//else number doesn't check
//end check answer

//remove leading zeros from answer:
while (s.charAt(0)=="0")
{
s=s.substring(1,s.length);
}
//we keep a zero if the number is purely decimal
if (s.charAt(0)==".")
s="0"+s;

//align the numbers by putting a space infront of the shortest number
for (var i=0;i<(xlen-ylen);i++)
y="&nbsp;"+y;

//note, we cannot use y or ylen anymore because y contains "&nbsp;
//which is 6 characters, creating one space!
//sign makes s positive or negative, as appropriate
s=sign+addseps(s);
var slen=s.length;
//pad out x and y so they line up with their decimals and the
//answer
for (var i=0;i<(slen-xlen);i++)
{
x="&nbsp;"+x;
y="&nbsp;"+y;
}
//finally, we put the numbers back in the right order,
//if y was bigger than x numerically, and the answer is negative
if (sign=="-")
{
temp=x;
x=y;
y=temp;
}
ans=s;
return s;

//document.getElementById("s1").innerHTML=(x)+"-<br><u>"+(y)+"</u>=<br>"+s+aCheck+"Javascript calculates: <br>"+jssum+"<br>"+mess;
}//end of else (numCheck OK)
}//end of  Sub(x,y)

function trimString(sInString) {
	if(sInString != null)
	{
    sInString = sInString.replace( /^\s+/g, "" );// strip leading
    return sInString.replace( /\s+$/g, "" );// strip trailing
  }
  else
    return "";
}

