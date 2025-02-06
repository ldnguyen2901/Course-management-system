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
<details>
<summary>Trường đại học Khoa Học Tự Nhiên (HCMUS)</summary>

3.1	Trường đại học Khoa Học Tự Nhiên

Trường Đại Học Khoa Học Tự Nhiên - Đại học Quốc gia thành phố Hồ Chí Minh (ĐHQG TP.HCM) là cơ sở đào tạo đại học, sau đại học và nghiên cứu khoa học (NCKH), chuyển giao công nghệ (CGCN) có nhiệm vụ đào tạo nhân lực, bồi dưỡng nhân tài, nghiên cứu và triển khai ứng dụng khoa học cơ bản và công nghệ về những ngành khoa học công nghệ (KHCN) có liên quan.

Trường Đại Học Khoa Học Tự Nhiên - ĐHQG TP.HCM có quyền hạn và nhiệm vụ theo quy định của Luật Giáo dục 2005, hướng dẫn thi hành một số điều của Luật Giáo dục quy định tại Nghị định số 75/2006/NĐ-CP ngày 02 tháng 8 năm 2006 của Chính phủ, Quy chế về tổ chức và hoạt động của Đại học Quốc Gia ban hành kèm theo Quyết định số 16/2001/QĐ-TT ngày 12 tháng 02 năm 2001 của Thủ tướng Chính phủ, Điều lệ trường đại học ban hành kèm theo Quyết định số 153/2003/QĐ-TTg ngày 30 tháng 7 năm 2003 của Thủ tướng Chính phủ.

Trường Đại Học Khoa Học Tự Nhiên chịu sự quản lý trực tiếp của ĐHQG TP.HCM. Trường Đại Học Khoa Học Tự Nhiên là tổ chức có tư cách pháp nhân, có con dấu và tài khoản riêng, được quyền tự chủ và tự chịu trách nhiệm theo quy định của pháp luật và của ĐHQG TP.HCM về quy hoạch, kế hoạch phát triển, tổ chức các hoạt động đào tạo, khoa học và công nghệ, tài chính, quan hệ quốc tế, tổ chức và nhân sự, có trách nhiệm phối hợp hoạt động chiến lược theo kế hoạch chung của ĐHQG TP.HCM.

3.2	Các Khoa

Khoa là đơn vị quản lý hành chính cơ sở của trường, có trách nhiệm chủ trì và phối hợp với các phòng, ban chức năng thực hiện các nhiệm vụ sau đây:
<ol type = "a" start="1">
<li>Xây dựng chương trình, kế hoạch giảng dạy, học tập và tổ chức quá trình đào tạo một hoặc một số ngành; tổ chức các hoạt động giáo dục khác trong chương trình, kế hoạch giảng dạy chung của nhà trường</li>
<li>Xây dựng kế hoạch và tổ chức thực hiện các hoạt động KHCN; triển khai thực hiện các dự án hợp tác quốc tế; phối hợp với các tổ chức KHCN, các doanh nghiệp; gắn hoạt động đào tạo với NCKH-CGCN, phát triển kinh tế xã hội. </li>
<li>Xây dựng quy hoạch, phát triển đội ngũ giảng viên. Quản lý, tổ chức đào tạo, bồi dưỡng nâng cao phẩm chất chính trị, tư tưởng, đạo đức, lối sống, trình độ chuyên môn, nghiệp vụ cho giảng viên và nhân viên thuộc khoa. Quản lý người học theo quy định của trường.</li>
<li>Quản lý chất lượng, nội dung, phương pháp đào tạo và NCKH; tổ chức biên soạn giáo trình; tổ chức nghiên cứu cải tiến phương pháp giảng dạy, học tập.</li>
<li>Đề xuất xây dựng kế hoạch phát triển, quản lý, bảo trì cơ sở vật chất trang thiết bị phục vụ đào tạo, NCKH-CGCN.</li>
</ol>

Đứng đầu các khoa là Trưởng khoa do Hiệu trưởng bổ nhiệm, miễn nhiệm. Giúp việc cho Trưởng khoa có các Phó trưởng khoa do Hiệu trưởng bổ nhiệm, miễn nhiệm theo đề nghị của Trưởng khoa. Nhiệm kỳ của Trưởng khoa và Phó trưởng khoa là 5 năm và có thể được bổ nhiệm lại nhưng không quá hai nhiệm kỳ liên tiếp.

3.3	Quy chế đào tạo theo học chế tín chỉ cho hệ đại học và cao đẳng chính quy

3.3.1	Chương trình đào tạo

Chương trình đào tạo (sau đây gọi tắt là chương trình) là những thông tin cơ bản mà sinh viên cần nắm vững trong quá trình học tập, bao gồm: mục tiêu đào tạo, chuẩn đầu ra kiến thức, kỹ năng, thái độ, trách nhiệm nghề nghiệp của sinh viên khi tốt nghiệp; khối lượng kiến thức lý thuyết, thực hành, thực tập; kế hoạch đào tạo theo thời gian thiết kế; phương pháp và hình thức đào tạo; cách thức đánh giá kết quả học tập; các điều kiện thực hiện chương trình. 

Mỗi chương trình gắn với một ngành hoặc với một vài ngành và được cấu trúc từ các học phần thuộc hai khối kiến thức: giáo dục đại cương và giáo dục chuyên nghiệp. Khối kiến thức giáo dục đại cương nhằm trang bị cho sinh viên nền học vấn rộng: có thế giới quan khoa học và nhân sinh quan đúng đắn; hiểu biết về tự nhiên, xã hội và con người; nắm vững phương pháp tư duy khoa học; có đạo đức, nhận thức trách nhiệm công dân; có năng lực tham gia xây dựng và bảo vệ đất nước. Khối kiến thức giáo dục chuyên nghiệp được thể hiện theo 2 nhóm: nhóm kiến thức cơ sở ngành hoặc liên ngành và nhóm kiến thức chuyên ngành, nhằm cung cấp cho sinh viên những kiến thức và kỹ năng nghề nghiệp ban đầu cần thiết.

Đề cương chi tiết của từng học phần thể hiện rõ mục tiêu, số lượng tín chỉ, điều kiện tiên quyết (nếu có), nội dung lý thuyết và thực hành, cách thức đánh giá học phần, giáo trình, tài liệu tham khảo và điều kiện thí nghiệm, thực hành, thực tập phục vụ học phần

3.3.2	Học phần và tín chỉ

Học phần là khối lượng kiến thức tương đối trọn vẹn, thuận tiện cho sinh viên tích lũy trong quá trình học tập. Nội dung được bố trí giảng dạy trọn vẹn và phân bố đều trong một học kỳ. Từng học phần được ký hiệu bằng một mã số riêng do trường quy định.
 	
Có hai loại học phần: học phần bắt buộc và học phần tự chọn: 
<ol type="a" start=1>
<li>Học phần bắt buộc là học phần chứa đựng những nội dung kiến thức chính yếu của mỗi chương trình và bắt buộc sinh viên phải tích lũy;
<li>Học phần tự chọn là học phần chứa đựng những nội dung kiến thức cần thiết, nhưng sinh viên được tự chọn theo hướng dẫn của Trường nhằm đa dạng hoá hướng chuyên môn hoặc được tự chọn tùy ý để tích lũy đủ số học phần quy định cho mỗi chương trình.
</ol>
Tín chỉ được sử dụng để tính khối lượng học tập của sinh viên. Một tín chỉ được quy định bằng 15 tiết học lý thuyết; 30 - 45 tiết thực hành, thí nghiệm hoặc thảo luận; 45 - 90 giờ thực tập tại cơ sở; 45 - 60 giờ làm tiểu luận, bài tập lớn hoặc đồ án, khóa luận tốt nghiệp. Một tiết học được tính bằng 50 phút.
<br><br>
Ngoài việc được phân loại là bắt buộc hoặc tự chọn, các học phần có các khái niệm khác như sau: 
<ol type="a" start=1>
<li>Học phần chung (Giáo dục Quốc phòng - An ninh, Giáo dục Thể chất, các học phần lý luận chính trị …) là các học phần được giảng dạy chung cho tất cả các ngành theo quy định.
<li>Học phần tiên quyết: một học phần là tiên quyết đối với học phần A là học phần mà sinh viên phải học và thi đạt mới được theo học phần A. 
<li>Học phần song hành: Hai học phần được gọi là song hành khi sinh viên đăng ký học phần này thì bắt buộc phải đăng ký học phần kia. 
<li>Học phần thay thế: là học phần được sử dụng thay thế cho một học phần đã được thay đổi hoặc điều chỉnh, không còn tổ chức giảng dạy trong chương trình. 
<li>Học phần tương đương: một học phần được gọi là tương đương với học phần A khi có nội dung kiến thức và thời lượng đáp ứng yêu cầu cơ bản của học phần A. 
<li>Học phần tự chọn định hướng: là học phần mà sinh viên phải chọn trong các học phần quy định cho một ngành, chuyên ngành cụ thể. 
</ol>Các học phần được gọi là tích lũy khi điểm đánh giá học phần đạt từ điểm 5,0 trở lên.
<br><br>
3.3.3	Tổ chức lớp 

1. Lớp học phần: Những sinh viên theo học cùng một học phần trong cùng một khoảng thời gian và cùng một giảng viên tạo thành một lớp học phần. Mỗi lớp học phần được ký hiệu bằng một mã số riêng do trường quy định. 
2. Lớp sinh hoạt: Những sinh viên cùng khóa tuyển, nếu có chung ≥ 60 % số lớp học phần trong tổng số các lớp học phần của cùng một học kỳ được tổ chức thành một lớp sinh hoạt. Lớp sinh hoạt nhằm mục đích tạo điều kiện cho sinh viên sinh hoạt đoàn thể.

3.4	Quá trình đăng ký học phần:

3.4.1	Khảo sát bên phòng đào tạo

Bên phòng đào tạo có thể thêm vào sinh viên mới trong mỗi khoá học mới, ví dụ như đầu năm học mới, các tân sinh viên được tuyển vào trường, phòng đạo tạo sẽ nhập các sinh viên này vào cơ sở dữ liệu của hệ thống nhà trường, để thực hiện việc quản lý sinh viên.

Một sinh viên sẽ được xác định bởi mã số sinh viên duy nhất, và 2 số đầu của mã sinh viên cho biết khoá học của sinh viên, ví dụ như mã số 19110317 tức là sinh viên này đã thi tuyển đầu vào năm 2019. Các thông tin khác về sinh viên như họ, tên đệm, tên, giới tính, ngày sinh và quê quán sinh viên. Mỗi sinh viên thuộc một khoa duy nhất, được xác định từ lúc sinh viên có nguyện vọng thi vào trường, ví dụ như sinh viên với mã số 19110442 thuộc về khoa Toán - Tin học. Ngoài ra, để tạo ra một nhóm sinh viên nòng cốt, ở mỗi khoa còn có việc tuyển chọn ra một lớp có điểm thi đầu vào cao và có nguyện vọng vào lớp học này, đó gọi là lớp cử nhân tài năng, được đào tạo riêng theo chương trình cử nhân tài năng, những sinh viên khác gọi là chính quy.

Đầu tiên các giảng viên trong trường sẽ có một buổi họp để thảo luận và chọn các môn mình sẽ đảm nhiệm dạy trong danh sách các môn học được mở trong học kì hiện tại đến khoa của mình đang công tác, sau khi tập hợp đầy đủ các thông tin, các khoa gửi đến phòng đạo tạo danh sách môn học kèm theo tên giảng viên để phòng đạo tạo phê duyệt và cập nhật đến sinh viên.

Một môn học được xác định mã môn học duy nhất, tên môn học và số tin chỉ ứng với môn học đó, ngoài ra một môn học còn có thể có các môn học tiên quyết của nó, tức là phải học các môn tiên quyết thì mới được phép đăng ký học môn học này.

Một lớp học phần sẽ được áp dụng cho một nhóm sinh viên nào đó được phép đăng ký. Các sinh viên này được phân nhóm theo khoa (ví dụ: nhóm sinh viên thuộc khoa Toán - Tin học, ...). Từng nhóm sinh viên theo khoa sẽ được phân ra các nhóm theo niên khoá (ví dụ: các sinh viên khoa Toán - Tin học khóa 2019, 2020, ...). Ở mỗi khoa, ứng với từng niên khóa sinh viên được chia ra làm 2 chương trình đào tạo: các sinh viên theo chương trình chính quy (CQ) và các sinh viên theo chương trình đào tạo cử nhân tài năng (CNTN). Vì vậy, phòng đào tạo sẽ phân sinh viên ra làm ba nhóm là theo khoa, niên khoá và chương trình đào tạo (CQ hoặc CNTN).

Một lớp học phần được lập ra sẽ có các thuộc tính như thời gian của lịch học được tạo ra, cụ thể là năm học và học kỳ. Một năm học sẽ có 2 hoặc 3 học kỳ, học kỳ thứ 3 gọi là học kỳ hè.

Một lớp học phần được lập ra phải cho biết học phần ứng với lớp học phần. Một học phần được xác định bởi mã học phần duy nhất, tên học phần và số tín chỉ.

Một lớp học phần phải cho biết lớp học phần đó có mã lớp là mã nào, ví dụ như môn Anh văn, khi một lớp học phần được lập ra áp dụng cho 1 nhóm cố định nào đó, thì có thể có nhiều lớp học phần áp dụng cho học phần đó nhưng khác mã số lớp, bởi vì số lượng rất đông nên phải chia thành nhiều lớp nhiều ca, do đó sẽ có thể có nhiều lớp học phần cho học phần này và các lớp mở ra sẽ có mã số lớp như A, B, C, D hoặc 1, 2, 3, 4. Thông thường các lớp học phần mở ra dành riêng cho lớp cử nhân tài năng sẽ có mã số lớp bắt đầu bằng chữ N.

Một lớp học phần sẽ cho biết tiết bắt đầu và tiết kết thúc của học phần đó. Một lớp học phần cho biết giảng viên phụ trách của môn học đó. Giảng viên xác định bởi tên duy nhất, học vị và email. Thực tế sẽ không có 2 giảng viên nào trùng tên trong trường do cách đặt thêm ký tự A, B, C vào mỗi giảng viên trùng tên, như Nguyễn Văn Thìn A, Nguyễn Văn Thìn B.

Ngoài ra một lớp học phần còn phải đảm bảo về số lượng tối đa sinh viên đăng ký.

Vì mỗi học kỳ ứng với mỗi năm học khác nhau, danh sách sinh viên và môn học có thể khác nhau, do đó phòng đào tạo phải cập nhật lại thông tin trước khi thời gian đăng ký bắt đầu.

Và sau khi hết thời gian đăng ký, có thể do một số lý do chính đáng; chẳng hạn như: số lượng sinh viên đăng ký lớp học phần đó nhỏ hơn một con số cụ thể (5) thì lớp học phần đó sẽ bị huỷ và sinh viên sẽ được đăng ký lại lớp học phần khác nếu cần; hoặc trong quá trình học tập có một vài lý do nào đó sinh viên không thể tiếp tục học thì có thể lên phòng đào tạo để hiệu chỉnh, với điều kiện là trong thời gian cho phép nào đó.


3.4.2	Khảo sát bên sinh viên

Trước khi bắt đầu cho học kỳ mới, phòng đào tạo sẽ mở ra một khoảng thời gian cho sinh viên đăng ký học phần.

Thủ tục đăng ký học phần như sau:

Sinh viên sẽ vào tài khoản của mình bằng cách đăng nhập bởi tên đăng nhập là mã số sinh viên (MSSV), và mật khẩu cho lần đầu tiên đăng nhập cũng chính là MSSV của sinh viên đó, sau khi đăng nhập lần đầu, sinh viên có thể thay đổi mật khẩu riêng của mình. Ví dụ sinh viên với mã số 19110317 sẽ được cấp một tài khoản với tên đăng nhập và mật khẩu là 19110317, sau đó sinh viên có quyền thay đổi mật khẩu.

Khi vào tài khoản của mình, sinh viên sẽ thấy ba mục: mục thông tin chung, mục đăng ký học phần, mục danh sách lớp mở.

Bấm vào mục thông tin chung, sinh viên sẽ thấy các thông tin về mình như Mã sinh viên, họ tên, giới tính, ngày sinh, khoa. 

Bấm vào mục danh sách lớp mở chứa danh sách các lớp được mở trong học kỳ này, tức là những môn học mà sinh viên được phép đăng ký trong học kỳ chuẩn bị học. Sinh viên thuộc nhóm nào, tức là ràng buộc với 3 yếu tố về khoá học, ngành học, chương trình đào tạo thì sẽ nhìn thấy danh sách môn học được phép đăng ký của mình khác nhau.

Còn ở mục đăng ký học phần sẽ là bảng danh sách các học phần cho phép sinh viên đăng ký học phần được mở ở học kì hiện tại. Trong bảng danh sách mỗi dòng là 1 học phần đăng ký. Thông tin mỗi học phần được phép đăng ký bao gồm Mã học phần, Tên học phần, TC (số tín chỉ của học phần), Lớp, Phòng, Sỉ số đăng ký (số sinh viên tối đa cho phép đăng ký), Đã đăng ký (số sinh viên đã đăng ký học phần đó), và một ô checkbox để sinh viên đánh dấu vào nếu có ý định chọn học phần đó. Sau khi đánh dấu tất cả các học phần mình đã chọn, sinh viên ấn vào nút Đồng Ý phía dưới để hệ thống nhập vào cơ sở dữ liệu xác nhận sinh viên đã đăng ký những học phần mình chọn, nếu sinh viên đăng ký vượt quá số tín chỉ hệ thống sẽ thông báo và không cho sinh viên đăng ký. Sau khi ấn nút Đồng Ý thì danh sách các học phần sinh viên đã đăng ký cũng hiển thị bên trên, đồng thời các học phần đăng ký hoặc những học phần trùng với học phần đã đăng ký nhưng khác lớp trong bảng danh sách các học phần cũng tự động ẩn đi. Trường hợp sau khi ấn Đồng Ý, sinh viên muốn thêm một số môn học nào nữa thì có thể làm tương tự như trước. Ngược lại, trường hợp sinh viên muốn huỷ bỏ học phần mà mình đã đã đăng ký thì ở cuối dòng mỗi học phần có ô checkbox để sinh viên đánh dấu nếu không muốn đăng ký học phần đó nữa. Sau khi sinh viên ấn nút huỷ đăng ký thì các học phần được chọn để huỷ cũng như các học phần trùng với học phần đó nhưng khác lớp cũng hiển thì trở lại trên danh sách các học phần cho phép đăng ký.

</details>