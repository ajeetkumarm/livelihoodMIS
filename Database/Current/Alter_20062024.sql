Alter Table M_DigitalCategory
Add DisplayOrder int not null default 0

Alter Table M_DigitalCategory
Add IsDeleted bit not null default 0

Alter Table M_DigitalService
Add DisplayOrder int not null default 0

Alter Table M_DigitalService
Add IsDeleted bit not null default 0



--Select * From M_DigitalCategory Where IsDeleted=0 Order By DisplayOrder

--Select * From M_DigitalService Where DigitalCategoryId=1 ANd DigitalCategoryId=1

----Update M_DigitalCategory SET DisplayOrder=1 Where CategoryId=2
----Update M_DigitalCategory SET DisplayOrder=2 Where CategoryId=1
----Update M_DigitalCategory SET DisplayOrder=3 Where CategoryId=3
----Update M_DigitalCategory SET DisplayOrder=4 Where CategoryId=4

----Update M_DigitalCategory SET DisplayOrder=5 Where CategoryId=6
----Update M_DigitalCategory SET DisplayOrder=6 Where CategoryId=5
----Update M_DigitalCategory SET DisplayOrder=7 Where CategoryId=8
----Update M_DigitalCategory SET DisplayOrder=8 Where CategoryId=9
----Update M_DigitalCategory SET DisplayOrder=9 Where CategoryId=10
----Update M_DigitalCategory SET DisplayOrder=10 Where CategoryId=7
----Update M_DigitalCategory SET DisplayOrder=11 Where CategoryId=11
----Update M_DigitalCategory SET DisplayOrder=12, Isdeleted=0 Where CategoryId=30


--Update M_DigitalService Set ServiceLine='Ayushman Bharat Yojana', DisplayOrder=1, UpdatedBy=1, UpdatedOn=GETDATE() Where ServiceId=1
--Update M_DigitalService Set ServiceLine='PM FasalBima Yojana', DisplayOrder=2, UpdatedBy=1, UpdatedOn=GETDATE() Where ServiceId=2
--Update M_DigitalService Set ServiceLine='PM - Ujjwala Scheme (LPG Booking)', DisplayOrder=3, UpdatedBy=1, UpdatedOn=GETDATE() Where ServiceId=3
--Update M_DigitalService Set ServiceLine='PM - Shram Yogi Maan-dhan Yojana', DisplayOrder=4, UpdatedBy=1, UpdatedOn=GETDATE() Where ServiceId=4
--Update M_DigitalService Set ServiceLine='PM - Kisan Maan-dhan Yojana', DisplayOrder=5, UpdatedBy=1, UpdatedOn=GETDATE() Where ServiceId=5
--Update M_DigitalService Set ServiceLine='PM - Kisan Samman Nidhi Yojana', DisplayOrder=6, UpdatedBy=1, UpdatedOn=GETDATE() Where ServiceId=6
--Update M_DigitalService Set ServiceLine='PM - Merchant Pension Yojana', DisplayOrder=6, UpdatedBy=1, UpdatedOn=GETDATE() Where ServiceId=7
--Update M_DigitalService Set ServiceLine='PM - Kisan Credit Cards Yojana', DisplayOrder=6, UpdatedBy=1, UpdatedOn=GETDATE() Where ServiceId=8
--Update M_DigitalService Set ServiceLine='PM - SVA Nidhi Yojana', DisplayOrder=6, UpdatedBy=1, UpdatedOn=GETDATE() Where ServiceId=9
--Update M_DigitalService Set ServiceLine='E-Shram Registrations', DisplayOrder=6, UpdatedBy=1, UpdatedOn=GETDATE() Where ServiceId=10

----Update M_DigitalService Set IsDeleted=1 Where ServiceId>10 ANd DigitalCategoryId=1