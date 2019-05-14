# sieuthidienthoai
`git: https://github.com/baolamtran/sieuthidienthoai`

## Hướng dẫn cấu hình
* Update .NET Core SDK 2.2
* Vào appsettings.json, trong "ConnectionStrings" thay BAOLAM thành tên sql server local của máy
* Mở terminal trong visual studio code (hoặc dùng cmd cd vào thư mục project) nhập dòng lệnh sau để migrate database:
``` shell
dotnet ef database update
```
#### Lưu ý
Database được migrate ở trên chỉ là database chứa các bảng trong diagram chưa có liên kết khóa ngoại, phải tự vào sql server management để viết thêm. (Server Name: BAOLAM (đã thay thế ở trên); Authentication: Windows Authentication)

## Call API
#### Create
https://localhost:5001/{ModelName}/Create
#### Update
https://localhost:5001/{ModelName}/Edit/id
#### Delete
https://localhost:5001/{ModelName}/Delete/id
#### Get
https://localhost:5001/{ModelName}/Details/id
#### Get List
https://localhost:5001/{ModelName}/Index

#### Lưu ý
##### API create không truyền id ở JSON
##### API update cần truyền id ở cả URL và JSON
* URL

https://localhost:5001/{ModelName}/Edit/id
* JSON

`{
  "id": "",
  "name": ""
}`
