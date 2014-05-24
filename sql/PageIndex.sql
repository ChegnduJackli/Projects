Use Student
GO

IF EXISTS (SELECT 1 FROM DBO.SYSOBJECTS WHERE NAME = 'PageIndex' AND TYPE = 'P')
BEGIN
	DROP PROCEDURE PageIndex
	print @@Servername + '-' +convert(varchar,getdate(),121) + '###' + DB_Name() + '.dbo.PageIndex dropped' 
END
GO

CREATE PROCEDURE PageIndex 
	@tblName varchar(255), -- ���� 
	@strGetFields varchar(1000) = '*', -- ��Ҫ���ص��� 
	@fldName varchar(255)='', -- ������ֶ��� 
	@PageSize int = 10, -- ҳ�ߴ�(ÿҳ��¼��) 
	@PageIndex int = 1, -- ҳ�� 
	@doCount bit = 0, -- ���ؼ�¼����, ��0ֵ�򷵻ؼ�¼�� 
	@OrderType bit = 0, -- ������������, ��0ֵ���� 
	@strWhere varchar(1500) = '' -- ��ѯ���� (ע��: ��Ҫ�� where) 
AS 
declare @strSQL varchar(5000) -- ����� 
declare @strTmp varchar(110) -- ��ʱ���� 
declare @strOrder varchar(400) -- �������� 

if @doCount != 0 
begin 
	if @strWhere !='' 
	set @strSQL = 'select count(*) as Total from [' + @tblName +'] where '+@strWhere 
	else 
	set @strSQL = 'select count(*) as Total from [' + @tblName + ']' 
end --���ϴ������˼�����@doCount���ݹ����Ĳ���0����ִ������ͳ�ơ����µ����д��붼��@doCountΪ0����� 
else 
begin 
if @OrderType != 0 -- ����(desc) 
begin 
	set @strTmp = '<(select min' 
	set @strOrder = ' order by [' + @fldName +'] desc' 
	--���@OrderType����0����ִ�н���������Ҫ! 
end 
else -- ����(asc) 
begin 
	set @strTmp = '>(select max' 
	set @strOrder = ' order by [' + @fldName +'] asc' 
end 
if @PageIndex = 1 --ҳ�� 
begin 
	if @strWhere != '' 
		set @strSQL = 'select top ' +str(@PageSize)+ ' ' +@strGetFields+ ' from [' + @tblName + '] where ' + @strWhere + ' ' + @strOrder 
	else 
		set @strSQL = 'select top ' +str(@PageSize)+' ' +@strGetFields+ ' from [' +@tblName+ '] ' +@strOrder 
--����ǵ�һҳ��ִ�����ϴ��룬������ӿ�ִ���ٶ� 
end 
else 
begin --���´��븳����@strSQL������ִ�е�SQL���� 
	set @strSQL = 'select top ' +str(@PageSize)+ ' ' +@strGetFields+ ' from [' +@tblName+ '] where [' +@fldName+ ']' +@strTmp+ '([' +@fldName+ ']) from (select top ' +str((@PageIndex-1)*@PageSize)+ ' [' +@fldName+ '] from [' +@tblName+ ']' +@strOrder+ ') as tblTmp)' +@strOrder 
	if @strWhere != '' 
		set @strSQL ='select top ' +str(@PageSize)+ ' ' +@strGetFields+ ' from [' +@tblName+ '] where [' +@fldName+ ']' +@strTmp+ '([' +@fldName+ ']) from (select top ' +str((@PageIndex-1)*@PageSize) + ' [' +@fldName+ '] from [' +@tblName+ '] where ' +@strWhere+ ' ' +@strOrder+ ') as tblTmp) and ' +@strWhere+ ' ' +@strOrder 
end 
end 
exec (@strSQL) 
GO

print @@Servername + '-' +convert(varchar,getdate(),121) + '###' + DB_Name() + '.dbo.PageIndex Created' 
GO