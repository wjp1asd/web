/* Common List Functions */
//highlight line
/******************************************/
/*���ܣ���������ʾ                        */
/*��������                                */
/*���أ���                                */
/******************************************/
function DoHL()
{
var e=window.event.srcElement;
while (e.tagName!="TR"){e=e.parentNode;}
if (e.className!='SL') e.className='HL';
}

/******************************************/
/*���ܣ���������ʾ                        */
/*��������                                */
/*���أ���                                */
/******************************************/
function DoLL()
{
var e=window.event.srcElement;
while (e.tagName!="TR"){e=e.parentNode;}
if (e.className!='SL')	e.className='';
}

/******************************************/
/*���ܣ�ѡ������ʾ                        */
/*��������                                */
/*���أ���                                */
/******************************************/
function DoSL()
{
var TB=e=window.event.srcElement;
while (TB.tagName!="TABLE")
{TB=TB.parentNode;}
for (var i=0;i<TB.rows.length;i++){
	if(TB.rows[i].className=='SL')TB.rows[i].className='';}
while (e.tagName!="TR"){e=e.parentNode;}
e.className=(e.className=='SL')?'':'SL';
}

/******************************************/
/*���ܣ�select line                       */
/*������                                  */
/*���أ�                                  */
/******************************************/
function hL(E){
while (E.tagName!="TR")
{E=E.parentNode;}
E.className="SL";
}
/******************************************/
/*���ܣ�diselect line                     */
/*������                                  */
/*���أ�                                  */
/******************************************/
function dL(E){
while (E.tagName!="TR")
{E=E.parentNode;}
E.className="";
}
