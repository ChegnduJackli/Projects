Use Student
GO

IF EXISTS (SELECT 1 FROM DBO.SYSOBJECTS WHERE NAME = 'PageIndex' AND TYPE = 'P')
BEGIN
	DROP PROCEDURE PageIndex
	print @@Servername + '-' +convert(varchar,getdate(),121) + '###' + DB_Name() + '.dbo.PageIndex dropped' 
END
GO

CREATE PROCEDURE PageIndex 
	@tblName varchar(255), -- 表名 
	@strGetFields varchar(1000) = '*', -- 需要返回的列 
	@fldName varchar(255)='', -- 排序的字段名 
	@PageSize int = 10, -- 页尺寸(每页记录数) 
	@PageIndex int = 1, -- 页码 
	@doCount bit = 0, -- 返回记录总数, 非0值则返回记录数 
	@OrderType bit = 0, -- 设置排序类型, 非0值则降序 
	@strWhere varchar(1500) = '' -- 查询条件 (注意: 不要加 where) 
AS 
declare @strSQL varchar(5000) -- 主语句 
declare @strTmp varchar(110) -- 临时变量 
declare @strOrder varchar(400) -- 排序类型 

if @doCount != 0 
begin 
	if @strWhere !='' 
	set @strSQL = 'select count(*) as Total from [' + @tblName +'] where '+@strWhere 
	else 
	set @strSQL = 'select count(*) as Total from [' + @tblName + ']' 
end --以上代码的意思是如果@doCount传递过来的不是0，就执行总数统计。以下的所有代码都是@doCount为0的情况 
else 
begin 
if @OrderType != 0 -- 降序(desc) 
begin 
	set @strTmp = '<(select min' 
	set @strOrder = ' order by [' + @fldName +'] desc' 
	--如果@OrderType不是0，就执行降序，这句很重要! 
end 
else -- 升序(asc) 
begin 
	set @strTmp = '>(select max' 
	set @strOrder = ' order by [' + @fldName +'] asc' 
end 
if @PageIndex = 1 --页码 
begin 
	if @strWhere != '' 
		set @strSQL = 'select top ' +str(@PageSize)+ ' ' +@strGetFields+ ' from [' + @tblName + '] where ' + @strWhere + ' ' + @strOrder 
	else 
		set @strSQL = 'select top ' +str(@PageSize)+' ' +@strGetFields+ ' from [' +@tblName+ '] ' +@strOrder 
--如果是第一页就执行以上代码，这样会加快执行速度 
end 
else 
begin --以下代码赋予了@strSQL以真正执行的SQL代码 
	set @strSQL = 'select top ' +str(@PageSize)+ ' ' +@strGetFields+ ' from [' +@tblName+ '] where [' +@fldName+ ']' +@strTmp+ '([' +@fldName+ ']) from (select top ' +str((@PageIndex-1)*@PageSize)+ ' [' +@fldName+ '] from [' +@tblName+ ']' +@strOrder+ ') as tblTmp)' +@strOrder 
	if @strWhere != '' 
		set @strSQL ='select top ' +str(@PageSize)+ ' ' +@strGetFields+ ' from [' +@tblName+ '] where [' +@fldName+ ']' +@strTmp+ '([' +@fldName+ ']) from (select top ' +str((@PageIndex-1)*@PageSize) + ' [' +@fldName+ '] from [' +@tblName+ '] where ' +@strWhere+ ' ' +@strOrder+ ') as tblTmp) and ' +@strWhere+ ' ' +@strOrder 
end 
end 
exec (@strSQL) 
GO

print @@Servername + '-' +convert(varchar,getdate(),121) + '###' + DB_Name() + '.dbo.PageIndex Created' 
GO