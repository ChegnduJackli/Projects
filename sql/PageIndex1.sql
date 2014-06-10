Use TaskTest
GO

IF EXISTS (SELECT 1 FROM DBO.SYSOBJECTS WHERE NAME = 'PageIndex' AND TYPE = 'P')
BEGIN
	DROP PROCEDURE PageIndex
	print @@Servername + '-' +convert(varchar,getdate(),121) + '###' + DB_Name() + '.dbo.PageIndex dropped' 
END
GO

CREATE PROCEDURE PageIndex
@tblName varchar(255), --table Name
@PageSize int = 10, --each page size
@PageIndex int = 1, --page index
@pageCount int =1 output, --return page count
@doCount int = 0 output, -- return records count
@strGetFields varchar(1000) = '*', --get which column names.
@OrderType varchar(20) = 0,--default is asc,0 means ASC, 1 means desc
@fldName varchar(100), --order by which field.
@strWhere varchar(1500) = '' --no need add 'where'
AS
declare @strSQL varchar(5000);
declare @strTmp varchar(110) ;
declare @strOrder varchar(400) ;
declare @strCount nvarchar(320);
declare @counts int ;
--get all records cout.
if(@strWhere != '' and @strWhere is not null) --has condition
begin
	set @strCount='select @counts = count(1)  from [' + @tblName + '] where ' + @strWhere + '';
end;
else
begin
	set @strCount='select @counts = count(1)  from [' + @tblName + '] ';
end;
exec sp_executesql @strCount,N'@counts int output',  @counts output;

if( @counts > 0 )
begin
	set @doCount = @counts;
	set @pageCount = @doCount / @PageSize;
end
print @pageCount;

if (@OrderType != 0) --not asc
begin
	set @strTmp = '<(select min ';
	set @strOrder = ' order by [' + @fldName +'] desc' ;
end;
else
begin
	set @strTmp = '<(select max ';
	set @strOrder = ' order by [' + @fldName +'] asc' ;
end;

if (@PageIndex = 1)
begin
	if(@strWhere != '' and @strWhere is not null) --has condition
		set @strSQL = 'select top ' +str(@PageSize)+ ' ' +@strGetFields+ ' from [' + @tblName + '] where ' + @strWhere + ' ' + @strOrder 
	else
		set @strSQL = 'select top ' +str(@PageSize)+' ' +@strGetFields+ ' from [' +@tblName+ '] ' +@strOrder 	
end;
else
begin

	if(@strWhere != '' and @strWhere is not null) --has condition
		set @strSQL ='select top ' +str(@PageSize)+ ' ' +@strGetFields+ ' from [' +@tblName+ '] where [' +@fldName+ ']' +@strTmp+ '([' +@fldName+ ']) from (select top ' +str((@PageIndex-1)*@PageSize) + ' [' +@fldName+ '] from [' +@tblName+ '] where ' +@strWhere+ ' ' +@strOrder+ ') as tblTmp) and ' +@strWhere+ ' ' +@strOrder 
	else
		set @strSQL = 'select top ' +str(@PageSize)+ ' ' +@strGetFields+ ' from [' +@tblName+ '] where [' +@fldName+ ']' +@strTmp+ '([' +@fldName+ ']) from (select top ' +str((@PageIndex-1)*@PageSize)+ ' [' +@fldName+ '] from [' +@tblName+ ']' +@strOrder+ ') as tblTmp)' +@strOrder ;
end;

exec (@strSQL);

print @strSQL;
go

print @@Servername + '-' +convert(varchar,getdate(),121) + '###' + DB_Name() + '.dbo.PageIndex Created' 
GO