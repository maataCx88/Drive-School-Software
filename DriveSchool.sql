use AutoDriveDB
create table ListOfExams(
idlist int primary key identity(1,1),
Category Nvarchar(50))
create table ListOfCandidats(
idcondidat int primary key identity(1,1),
candidate_list int foreign key references ListOfExams(idlist) on delete cascade,
candidat_name nvarchar(50),
candidat_lastname nvarchar(50),
Birthday int,
categoryCC	NVARChar(50),
Result nvarchar(50) default null)
select * from ListOfCandidats
insert into ListOfExams(Category) values(N'شفهي'),(N'مناورات'),(N'سياقة')

alter proc add_to_1_list
@name nvarchar(50),@lastname nvarchar(50),@birth int , @CatCC nvarchar(50),@Result nvarchar(50)
as
begin
insert into ListOfCandidats(candidate_list,candidat_name,candidat_lastname,Birthday,categoryCC,Result)
values(1,@name,@lastname,@birth,@CatCC,@Result)
end 
update ListOfCandidats set candidate_list=1 where idcondidat<4
ALTER proc add_to_2_list
@id int
as
begin
update ListOfCandidats set candidate_list=2 where idcondidat=@id
end

create proc add_to_3_list
@id int
as
begin
update ListOfCandidats set candidate_list=3 where idcondidat=@id
end
select * from ListOfCandidats
alter proc affichage_1_list
as
begin
select lc.idcondidat,lc.idcondidat as 'n°',lc.candidat_lastname as 'اسم المترشح',lc.candidat_name AS '  لقب المترشح ',lc.Birthday  as 'تاريخ الميلاد',lc.categoryCC  as 'الصنف',lc.Result as 'النتيجة' from ListOfCandidats as LC ,ListOfExams as LE
where LC.candidate_list=LE.idlist and LE.idlist=1
end --,lc.Result as 'النتيجة'and LE.idlist=2 and lc.idcondidat > 4


alter proc affichage_2_list
as
begin
select lc.idcondidat,lc.idcondidat as 'n°',lc.candidat_lastname as 'اسم المترشح',lc.candidat_name '  لقب المترشح',lc.Birthday  as 'تاريخ الميلاد',lc.categoryCC  as 'الصنف',lc.Result as 'النتيجة' from ListOfCandidats as LC ,ListOfExams as LE
where LC.candidate_list=LE.idlist and LE.idlist=2
end
alter proc affichage_3_list
as
begin
select lc.idcondidat,'',lc.candidat_lastname as 'اسم المترشح',lc.candidat_name as ' لقب المترشح ',lc.Birthday  as 'تاريخ الميلاد',lc.categoryCC  as 'الصنف',lc.Result as 'النتيجة' from ListOfCandidats as LC ,ListOfExams as LE
where LC.candidate_list=LE.idlist and LE.idlist=3
end
alter proc update_result
@id int , @result nvarchar(50)
as
update ListOfCandidats set Result=@result where idcondidat=@id


