# Course Management System

# Chương 1: Phát biểu bài toán
## 1. Xác định vị trí
Cơ hội: Việc có một hệ thống quản lý học phần, lớp học phần đồng thời quản lý việc đăng ký của sinh viên rất cần thiết.

Trình bày vấn đề: Vấn đề lưu trữ việc đăng ký môn học của sinh viên:
- Vấn đề: Cơ sở dữ liệu về việc đăng ký học phần của sinh viên được lưu trữ thủ công trên giấy làm cho việc quản lý khó khăn
- Các đối tượng có liên quan: Nhân viên phòng đào tạo, người quản lý
- Các ảnh hưởng của vấn đề: Làm việc quản lý lớp học cho từng học phần trở nên khó khăn và tốn nhiều thời gian 
- Giải pháp đề nghị: Tạo hệ thống tích hợp cơ sở dữ liệu giúp việc truy vấn danh sách đăng ký của sinh viên dễ dàng hơn.

Vấn đề lưu trữ danh sách lớp học phần mở kỳ này:
- Vấn đề: Cơ sở dữ liệu về danh sách các lớp học phần được mở ở học kỳ hiện tại được lưu trữ thủ công trên giấy làm cho việc quản lý khó khăn
- Các đối tượng có liên quan: Nhân viên phòng đào tạo, sinh viên
- Các ảnh hưởng của vấn đề: Làm việc quản lý lớp học phần cũng như việc đăng ký của sinh viên trở nên khó khăn và tốn nhiều thời gian
- Giải pháp đề nghị: Tạo hệ thống tích hợp cơ sở dữ liệu giúp việc quản lý danh sách lớp học phần dễ dàng hơn,

## 2. Mô tả Stakeholder và khách hàng
 - Tóm tắt các Stakeholder

| Name | Represent | Role |
|------|-----------|------|
Người quản lý | Người quản lý phòng đào tạo | Theo dõi tiến trình phát triển dự án và theo dõi tình hình phòng đào tạo | 
Nhân viên phòng đào tạo | Người nhập các thông tin | Chịu trách nhiệm việc cập nhập thông tin học phần 
Khoa | Đơn vị quản lý đào tạo cơ sở của trường đại học | Tổ chức hoạt động giáo dục trong chương trình giảng dạy của nhà trường
Giảng viên | Người thực hiện hoạt động giảng dạy ở trường đại học | Đảm nhận giảng dạy lớp học phần

- Tóm tắt các khách hàng

| Name                    | Description                                                                 | Stakeholder             |
| ----------------------- | --------------------------------------------------------------------------- | ----------------------- |
| Người quản lý           | Đáp ứng các nhu cầu quản lý hệ thống                                        | Người quản lý           |
| Nhân viên phòng đào tạo | Đảm bảo rằng hệ thống sẽ đáp ứng các nhu cầu của công việc quản lý học phần | Nhân viên phòng đào tạo |
| Sinh viên               | Đáp ứng nhu cầu đăng ký môn học                                             |                         |

- Hồ sơ về các stakeholder và khách hàng
    - Người quản lý:

    | **Vai trò**      | Người quản lý phòng đào tạo trường đại học                                                                                      |
    | ---------------- | ------------------------------------------------------------------------------------------------------------------------------- |
    | **Miêu tả**      | Người quyết định xây dựng hệ thống, theo dõi hoạt động của phòng đào tạo đồng thời quản lý nhân viên phòng đào tạo.             |
    | **Loại**         | Người hiểu rõ tình trạng hoạt động của phòng đào tạo                                                                            |
    | **Trách nhiệm**  | Mô tả cấu trúc tổ chức và tình trạng hoạt động của phòng đào tạo đồng thời quan sát tình trạng dự án.                           |
    | **Tiêu Chí**     | Sự thành công là hoàn thành công việc đúng thời gian và tổ chức tốt cơ sở thiết kế để tiện cho việc cải thiện hệ thống sau này. |
    | **Tham gia**     | Project reviewer, admin                                                                                                         |
    | **Bàn giao**     | Có, phân phối cho các đồng sự quản lý khác                                                                                      |
    | **Nhận/ Vấn đề** | Thời gian thực hiện ngắn so với khối lượng công việc quản lý phòng đào tạo quá nhiều                                            |

    - Nhân viên phòng đào tạo:

    | **Vai trò**      | Nhân viên ở phòng đào tạo                                                         |
    | ---------------- | --------------------------------------------------------------------------------- |
    | **Miêu tả**      | Nhân viên làm việc cho trường đại học thuộc phòng đào tạo, thực hiện nghiệp vụ mở |
    | **Loại**         | Người có trình độ tin học nhất định và nghiệp vụ mở lớp học phần                  |
    | **Trách nhiệm**  | Lập báo cáo cho người quản lý                                                     |
    | **Tiêu Chí**     | Sự thành công là hoàn thành công việc hiệu quả, chính xác và nhanh chóng          |
    | **Tham gia**     | User                                                                              |
    | **Bàn giao**     | Có, phân phối cho các nhân viên phòng đào tạo khác                                |
    | **Nhận/ Vấn đề** | Một số thao tác còn thủ công, tốn thời gian quản lý học phần                      |

    - Giảng viên:

    | **Vai trò**      | Giảng viên dạy học ở trường đại học                                                 |
    | ---------------- | ----------------------------------------------------------------------------------- |
    | **Miêu tả**      | Người thực hiện hoạt động giảng dạy                                                 |
    | **Loại**         | Người có trình độ, học vấn cao về ngành nghề giảng dạy                              |
    | **Trách nhiệm**  | Giảng dạy, đánh giá trình độ học của sinh viên và lập báo cáo điểm số của sinh viên |
    | **Tiêu Chí**     | Không có                                                                            |
    | **Tham gia**     | Không có                                                                            |
    | **Bàn giao**     | Không có                                                                            |
    | **Nhận/ Vấn đề** | Thông tin về lớp học dễ lẫn lộn                                                     |

    - Khoa:

    | **Vai trò**      | Khoa-bộ môn trong trường đại học                                     |
    | ---------------- | -------------------------------------------------------------------- |
    | **Miêu tả**      | Đơn vị quản lý hành chính của trường đại học                         |
    | **Loại**         | Không có                                                             |
    | **Trách nhiệm**  | Quản lý các giảng viên và cung cấp danh sách giảng viên đảm nhận lớp |
    | **Tiêu Chí**     | Không có                                                             |
    | **Tham gia**     | Không có                                                             |
    | **Bàn giao**     | Không có                                                             |
    | **Nhận/ Vấn đề** | Không có                                                             |

    - Sinh viên:

    | **Vai trò**      | Học viên tại trường đại học                      |
    | ---------------- | ------------------------------------------------ |
    | **Miêu tả**      | Người đăng ký học phần                           |
    | **Loại**         | Không có                                         |
    | **Trách nhiệm**  | Không có                                         |
    | **Tiêu Chí**     | Sự thành công là có hệ thống dễ đăng ký học phần |
    | **Tham gia**     | User                                             |
    | **Bàn giao**     | Không có                                         |
    | **Nhận/ Vấn đề** | Quy trình đăng ký môn học chưa được tiện lợi     |

## 3 Khảo sát hệ thống
