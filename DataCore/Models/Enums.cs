﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCore.Models
{
    public enum EmployeeStatusEnum
    {
        DeActive = 0,
        Active = 1
    }
    public enum ShiftRegisterEnum
    {
        [Display(Name = "Chờ duyệt")]
        Watting = 0,
        [Display(Name = "Đã duyệt")]
        Accept =  1
    }
    public enum EmployeeAttributeEnum
    {
        [Display(Name = "Thâm niên")]
        TN = 1,
        [Display(Name = "Chức vụ")]
        CV = 2,
        [Display(Name = "Con cái")]
        CN1 = 3,
        [Display(Name = "Người thân")]
        NT = 4,
        [Display(Name = "Lương cơ bản")]
        LCB = 5,
        [Display(Name = "Phương tiện di chuyển")]
        PTDC = 6,
        [Display(Name = "Tình trạng sức khỏe")]
        TTSK = 7,
        [Display(Name = "Ngày kết hôn")]
        KH = 8,
        [Display(Name = "Điện thoại")]
        DT = 9,
        [Display(Name = "Trang phục")]
        TP = 10,
    }
    public enum PayrollDetailCatetoryEnum
    {
        [Display(Name = "Basic")]
        Basic = 7,
        [Display(Name = "Formula")]
        Formula = 10,
        [Display(Name = "Other")]
        Other = 11,
    }
    public enum PriorityDayTypeEnum
    {
        [Display(Name = "Thấp")]
        Low = 1,
        [Display(Name = "Trung bình")]
        Medium = 2,
        [Display(Name = "Cao")]
        High = 3,
    }
    public enum EmployeeWorktypeENum
    {
        [Display(Name = "Theo tháng")]
        TT = 1,
        [Display(Name = "Theo giờ")]
        TG = 2,
    }
    public enum PositionEnum
    {
        [Display(Name = "Cửa hàng trưởng")]
        CHT = 1,
        [Display(Name = "Nhân viên")]
        NV = 2,
    }

    public enum FrequencyEnum
    {
        [Display(Name = "Theo kỳ lương")]
        TKL = 1,
        [Display(Name = "Theo tháng")]
        TTH = 2,
        [Display(Name = "Theo ngày")]
        TNG = 3,
        [Display(Name = "Theo giờ")]
        TGI = 4,
    }

    public enum VariabilityEnum
    {
        [Display(Name = "Tùy theo thời gian làm")]
        TTGL = 1,
        [Display(Name = "Tùy theo thời gian làm nhưng bỏ OT")]
        TTGLBOT = 2,

    }
    public enum DestinationEnum
    {
        [Display(Name = "Lương cơ bản")]
        LCB = 1,
        [Display(Name = "Lương tính thuế")]
        LTT = 2,
        [Display(Name = "Lương tính thuế TNCN")]
        TNCN = 3,
        [Display(Name = "Lương tính thuế BHXH")]
        BHXH = 4,
        [Display(Name = "Lương sau thuế")]
        LST = 5
    }
    
    public enum TimeSummaryEnum
    {
        Waiting = 1,
        Accept = 2,
        Reject = 3,
    }
    public enum DayTypeEnum
    {
        [Display(Name = "Ngày thường")]
        Norm = 0,
        [Display(Name = "Ngày nghỉ")]
        Rest = 1,
        [Display(Name = "Ngày lễ")]
        Holi = 2,
        [Display(Name = "Ngày lễ Tết")]
        TetHoli = 3,
        [Display(Name = "Ngày nghỉ trùng lễ")]
        RestHoli = 4,
        [Display(Name = "Ngày nghỉ trùng lễ Tết")]
        RestTetHoli = 5,
    }
    public enum ResultEnum
    {
        Unauthorization = -1,
        Success = 0,
        InternalError = 1,
        ModelError = 2,
        EmpNotFound = 3,
        TimeFrameNotFound = 4,
        PeriodNotFound = 5,
        BearerTokenNotFound = 6,
        NotActive = 7,
        AttributeWrong = 8,
        RoleNotSupport = 9,
        AuthorizationNotFound = 10,
        NotAcceptable = 11,
    }

    public enum WorkingShiftTypeEnum
    {
        [Display(Name = "Ca chính")]
        CaChinh = 0,
        [Display(Name = "Ca OT")]
        CaOT = 1,
    }
    public enum DaysOfWeekEnum
    {
        [Display(Name = "Thứ Hai")]
        Monday = 2,
        [Display(Name = "Thứ Ba")]
        Tuesday = 3,
        [Display(Name = "Thứ Tư")]
        Wednesday = 4,
        [Display(Name = "Thứ Năm")]
        Thursday = 5,
        [Display(Name = "Thứ Sáu")]
        Friday = 6,
        [Display(Name = "Thứ Bảy")]
        Saturday = 7,
        [Display(Name = "Chủ Nhật")]
        Sunday = 8
    }
    public enum PriorityEnum
    {
        [Display(Name = "Thông Thường")]
        Normal = 0,
        [Display(Name = "Quan Trọng")]
        Important = 1
    }
    public enum AttendanceStatusEnum
    {
        [Display(Name = "Waiting")]
        Waiting = 1,
        [Display(Name = "Accept")]
        Accept = 2,
        [Display(Name = "Reject")]
        Reject = 3
    }
    public enum RoleEnum
    {
        [Display(Name = "Nhân viên")]
        [Required]
        Employee = 1,
        [Display(Name = "Quản lý")]
        StoreManager = 2
    }

    public enum BirthdayOptionFilterEnum
    {
        ThisMonth = -1,
        BirthdayMonth = 1,
        BirthdayRange = 2
    }

    public enum RouteConnection
    {
        BlogCategoryMain = 0,
        BlogCategoryTypeNews = 1,
        BlogCategoryTypeVideo = 2,
        BlogCategoryTypeEvents = 3,
        BlogCategoryTypeResource = 4,
        BlogTypeNews = 5,
        BlogTypeVideo = 6,
        BlogTypeEvent = 7,
        BlogTypeResource = 8,
        BlogCollection = 9,
    }

    public enum BlogCateTypeEnum
    {
        [Display(Name = "Tin tức")]
        News = 1,
        [Display(Name = "Video")]
        Video = 2,
        [Display(Name = "Sự kiện")]
        Event = 3,
        [Display(Name = "Resource")]
        Resource = 4
    }

    public enum BlogTypeEnum
    {

        [Display(Name = "Tin tức")]
        News = 1,
        [Display(Name = "Video")]
        Video = 2,
        [Display(Name = "Sự kiện")]
        Event = 3,
        [Display(Name = "Resource")]
        Resource = 4
    }

    public enum SMSTypeEnum
    {
        [Display(Name = "Brand Name Quảng Cáo")]
        BrandNameCSKH = 2,
        [Display(Name = "Brand Name CSKH")]
        BrandNameAdvertysing = 1,
        [Display(Name = "Đầu số ngẫn nhiên")]
        RandomPhone = 3,
        [Display(Name = "Đầu số cố định")]
        FixPhone = 4,
        [Display(Name = "Đầu số 8755")]
        FixPhoneRegister = 6,
        [Display(Name = "Tốc độ cao đầu số ngẫu nhiên")]
        FastConnectRandomPhone = 7,
        [Display(Name = "Tốc độ cao đầu số cố định")]
        FastConnectFixPhone = 8
    }

    public enum CurrentStatusEnum
    {
        [Display(Name = "Tương lai")]
        Future = 0,
        [Display(Name = "Quá khứ")]
        Past = 1,
        [Display(Name = "Hiện tại")]
        Current = 3,
    }

    public enum StatusAttendance
    {
        [Display(Name = "Đi trễ")]
        ComeLate = 0,
        [Display(Name = "Về sớm")]
        ReturnEarly = 1,
        [Display(Name = "Đúng giờ")]
        OnTime = 3,
        [Display(Name = "Vắng")]
        Miss = 4,
        [Display(Name = "Vi phạm cả 2")]
        Bothviolate,
    }

    public enum RoomStatusEnum
    {
        Ready = 1,
        InUse = 2,
        Prepare = 3,
        NotUse = 4
    }

    public enum SessionStatusEnum
    {
        Open = 0,
        Close = 1,
        Modified = 2,
        Approve = 3,
        Empty = 4

    }

    public enum CostTypeEnum
    {
        [Display(Name = "Phiếu thu")]
        ReceiveCost = 1,
        [Display(Name = "Phiếu chi")]
        SpendingCost = 2,
        [Display(Name = "Phiếu thu xuất kho")]
        ReceiveCostTranferOut = 3,
        [Display(Name = "Phiếu chi nhập kho")]
        SpendingCostTranferIn = 4,
    }

    public enum ReceiveCostTypeEnum
    {
        [Display(Name = "Phiếu thu bình thường")]
        Normal = 1,
        [Display(Name = "Phiếu thu nợ")]
        PayDebt = 2,
        [Display(Name = "Phiếu thu khác")]
        Other = 3,
        [Display(Name = "Phiếu thu xuất kho")]
        OutInventory = 4,
    }

    public enum SpendingCostTypeEnum
    {
        [Display(Name = "Phiếu chi bình thường")]
        Normal = 1,
        [Display(Name = "Phiếu chi khác")]
        Other = 2,
        [Display(Name = "Phiếu chi nhập kho")]
        InInventory = 3,
    }

    public enum SaleTypeEnum
    {
        DefaultNothing = 0,
        DefaultAtStore = 1,
        DefaultTakeAway = 2,

    }

    public enum RoomStateEnum
    {
        Ready = 1,
        RentHour = 2,
        RentNight = 3,
        RentDay = 4,
        Prepare = 5,
        NotUse = 6
    }



    /// <summary>
    /// Loai hoa don cho loai hinh Khach san -- Database: RentType
    /// </summary>
    public enum RentTypeEnum
    {
        Default = 0,
        Hour = 1,
        Night = 2,
        Day = 3,
        Addition = 5,
        Booking = 7,
        Drinking = 4,
    }

    public enum BlogStatusEnum
    {
        [Display(Name = "Đang xử lý")]
        Processing = 0,
        [Display(Name = "Đã duyệt")]
        Approve = 1,
        [Display(Name = "Từ chối")]
        Reject = 2
    }

    public enum EventStatusEnum
    {
        [Display(Name = "Đã diễn ra")]
        Happened = 1,
        [Display(Name = "Đang diễn ra")]
        Happening = 2,
        [Display(Name = "Sắp diễn ra")]
        Comming = 3
    }


    /// <summary>
    /// Loại hóa đơn cho loại hình Cafe, Giao hàng --Database: OrderType 
    /// </summary>
    public enum OrderTypeEnum
    {
        [Display(Name = "Tại quán")]
        AtStore = 4,
        [Display(Name = "Mang đi")]
        TakeAway = 5,
        [Display(Name = "Giao hàng")]
        Delivery = 6,
        [Display(Name = "Bị hủy")]
        DropProduct = 8,
        [Display(Name = "Đặt hàng Online")]
        OnlineProduct = 1, // sản phẩm được đặt online
        [Display(Name = "Nạp thẻ")]
        OrderCard = 7
    }


    /// <summary>
    /// BUSINESS LOGIC:
    /// 1. Khách đặt phòng : New (chỉ đặt loại phòng - không xác định phòng cụ thể)
    /// 2. Nhân viên xử lý: New -> Waiting: nếu chưa có phòng
    /// 3. Nhân viên xử lý: New -> Accepted:  có phòng chưa xác định phòng
    /// 
    /// 4. Nhân viên xử lý: Accepted -> Assigned: cấp phòng 
    /// </summary>
    public enum RentStatusEnum
    {
        IsNotRent = 0,
        InStay = 1,//Dang o 
        Leave = 2,
        Approved = 3,
        Disabled = 4,
        WaitDisabled = 5,
        DeletePermanent = 6,
        New = 7, //Moi tao co the qua waiting hoac accept. Khong xu ly dc (khong co quota) -> waiting
        Waiting = 8, // Waiting -> accept
        Accepted = 9, //Sau khi accept xong moi duoc assign phong
        Assigned = 10,
        Queue = 11, //Assign -> Queue neu luc do phong chua don , Queue -> InStay
        //Delivering = 13, //Cho chuc nang giao hang

    }

    /// <summary>
    /// Trạng thái của đơn hàng là quán cafe hoặc giao hàng
    /// </summary>
    public enum OrderStatusEnum
    {
        [Display(Name = "Mới")]
        New = 8, //Đơn hàng mới tạo, từ tổng đài,web...//DeliveryStatus: New,Assgigned

        //Hai truong hop: Khach dang uong tai quan - Don hang Delivery dang duoc xu ly
        [Display(Name = "Đang xử lý tại POS")]
        PosProcessing = 17,
        [Display(Name = "Đang xử lý")]
        Processing = 10,//DeliveryStatus: POSAccepted, PosUnAccepted, Delivery

        [Display(Name = "Hoàn thành tại POS")]
        PosFinished = 11,//Ket thuc o POS: POSFinished ->Finish//For POS online
        [Display(Name = "Hoàn thành")]
        Finish = 2,//Don hang da gui len Server thanh cong: 

        [Display(Name = "Hủy sau chế biến tại POS")]
        PosCancel = 13,
        [Display(Name = "Hủy sau chế biến")]
        Cancel = 3,// Don hang da bi huy SAU KHI CHẾ BIẾN//DeliveryStatus: Cancel,Fail,Precancel

        [Display(Name = "Hủy trước chế biến tại POS")]
        PosPreCancel = 12,//Don hang bi huy truoc khi che bien - CHUA SUBMIT LEN SERVER
        [Display(Name = "Hủy trước chế biến")]
        PreCancel = 4,//Don hang bi huy truoc khi che bien - DA SUBMIT LEN SERVER

        [Display(Name = "Đã nhận tiền")]
        Paid = 5,// Hoa don da nhan tien
        [Display(Name = "Chưa nhận tiền")]
        Unpaid = 6,// Hoa don chua nhan tien
        [Display(Name = "Tạo mới ở Website")]
        WebNew = 14, // Hóa đơn mới được tạo
        [Display(Name = "Đã duyệt")]
        WebApproved = 15, // Hóa đơn đã được duyệt
    }

    public enum OrderPaymentStatusEnum
    {
        Finish = 0,
        Debt = 1,
    }





    public enum DeliveryStatus
    {

        New = 0,//Mới them vao chua tim duoc cua hang
        Assigned = 1,//Da gan cho cua hang

        POSAccepted = 2,//May POS da nhan duoc

        Delivery = 3,//Dang di giao

        Finish = 4,//Da hoan thanh

        PreCancel = 5,//Huy truoc khi che bien

        Cancel = 6,//Huy sao khi che bien

        Fail = 7,//Khong tim thay khach hang

        POSUnaccepted = 8,//May POS da nhan duoc nhung kg dap ung

        NotDelivery = 9

        //ApiOrder = 9 // Order from ApiOrder
    }




    public enum OrderDetailStatusEnum
    {
        New, //Mới đặt
        Processing, //Đang xử lý 
        Served, //Đã phục vụ
        Cancel, //Đã xong
    }


    /// <summary>
    /// Nguồn đặt hàng
    /// </summary>
    public enum OrderSourceEnum
    {
        InStore = 0,
        Website = 1,
        Facebook = 2,
        CallCenter = 3
    }

    public enum SubRentErrorTypeEnum
    {
        NonQuota = 1,
        NotEnoughQuantity = 2,
        Conflict = 3,
        Unchecked = 4,
        NonError = 5
    }

    public enum DateReportStatusEnum
    {
        Approved = 1,
        InProcess = 2
    }

    public enum PaymentReportStatusEnum
    {
        Approved = 1,
        InProcess = 2
    }

    public enum CostStatusEnum
    {
        New = 1,
        Approved = 2,
        WaitDisabled = 3,
        Disabled = 4,
        Deleted = 5
    }

    public enum PaymentStatusEnum
    {
        New = 0,
        Approved = 1,
        WaitDisabled = 2
    }

    public enum CashReportType
    {
        Payment = 0,
        Cost = 1
    }

    public enum BookingStatus
    {
        Unhandle = 0,
        Handled = 1,
        Cancel = 2,
    }

    public enum BookingItemStatus
    {
        NoError = 0,
        Error = 1,
        Cancel = 2,
        Unhandle = 3,
        Served = 4
    }

    public enum BookingDetailStatus
    {
        NoError = 0,
        Error = 1,
        Cancel = 2
    }

    public enum QuotaManagementMessage
    {
        AddSuccess = 1,
        EditSuccess = 2,
        DeleteSuccess = 3,
        ParseValueError = 4,
        DuplicateDate = 5,
        AddPastError = 6,
        UpdatePastError = 7,
        UnavailableError = 8,
        OverlapError = 9,
    }

    public enum OrderDetailStatus
    {
        Ordered = 0,
        Served = 1,
        Paid = 2,
        Delivery = 3,
        Finish = 11

    }

    public enum FeeCalculationType
    {
        Room = 0,
        Table = 1,
        Others = 2
    }

    public enum OfflineServiceStatus
    {
        Unchange = 0,
        New = 1,
        Modified = 2,
        Deleted = 3
    }

    //doi ten enum customertypeenum thanh membershiptype dien ta field 'type' cua bang customer 
    //de tranh nham lan voi field 'customertypeid' 
    public enum MembershipTypeEnum
    {
        //khach hang ko la thanh vien
        Default = 0,
        //khach hang la nguoi mua hang
        Customer = 1,
        //khach hang la doi tac
        Partner = 2
    }
    public enum MembershipStatusEnum
    {
        [Display(Name = "Chưa kích hoạt")]
        Inactive = 0,
        [Display(Name = "Đang sử dụng")]
        Active = 1,
        [Display(Name = "Tạm dừng")]
        Suspensed = 2,
    }

    public enum AccountCategory
    {
        System = 0,
        Store = 1,
        Cashier = 2,
        Customer = 3,
        Bank = 4,
    }

    public enum Currency
    {
        VND = 0,
        USD = 1
    }

    public enum PromotionTypeEnumForDetail
    {
        Order_DiscountPercent_IsMember = 0,
        Order_DiscountPercent_Everyone = 1,
        Order_Gift_IsMember = 2,
        Order_Gift_Everyone = 3,
        Order_DiscountCash_IsMember = 4,
        Order_DiscountCash_Everyone = 5,
        OrderDetail_DiscountPercent_IsMember = 6,
        OrderDetail_DiscountPercent_Everyone = 7,
        OrderDetail_Gift_IsMember = 8,
        OrderDetail_Gift_Everyone = 9,
        OrderDetail_DiscountCash_IsMember = 10,
        OrderDetail_DiscountCash_Everyone = 11,
    }

    public enum ProductTypeEnum
    {
        [Display(Name = "Sản Phẩm Đơn")]
        Single = 0,
        [Display(Name = "Phòng")]
        Room = 2,
        [Display(Name = "Sản phẩm khuyến mãi")]
        AdditionFee = 3,
        [Display(Name = "Sản phẩm kèm")]
        Extra = 5,
        [Display(Name = "Sản phẩm Master")]
        General = 6,
        [Display(Name = "Sản phẩm con")]
        Detail = 7,
        [Display(Name = "Card")]
        CardPayment = 8,
        [Display(Name = "Combo")]
        Combo = 1,
        [Display(Name = "Mẫu thẻ")]
        Sample = 9

    }

    public enum ProductGroupEnum
    {
        Hot = 0,
        Ice = 1,
        Cake = 2
    }


    //Chuyển hàng đi - Chuyển hàng đến (Exception)
    //1. Ben chuyen tao don hang moi: CHUA DUYET
    //1.1 Bên chuyển đã tạo mới nhưng muốn hủy : CHUA DUYET -> HUY
    //2. Ben nhận chấp nhận đơn hàng : ĐÃ DUYỆT
    //2.1 Bên nhận sau khi duyệt thì muốn từ chối:ĐÃ TỪ CHỐI
    //2.2 Bên gửi sau khi đã được duyệt muốn từ chối:XIN HỦY
    //2.2.1 Bên nhận đồng ý HỦY => HUỲ
    //3. Bên nhận không chấp nhận: ĐÃ TỪ CHỒI
    //3.1  Bên gửi đồng ý: HỦY

    //4. Báo cáo end of day
    // 4.1 Chưa duyệt, đã từ chối , đã hủy -> HỦY
    // 4.2 Đã duyệt -> Đóng
    public enum InventoryReceiptStatusEnum
    {
        [Display(Name = "Chưa duyệt")]
        New = 0,
        [Display(Name = "Đã duyệt")]
        Approved = 1,
        [Display(Name = "Đã hủy")]
        Canceled = 2,
        [Display(Name = "Đã từ chối")]
        Reject = 3,
        [Display(Name = "Đã đóng")]
        Closed = 4,
        //2 status này để biết cửa hàng nào request cancel
        [Display(Name = "Cửa hàng đi yêu cầu hủy")]
        InStoreCancelRequested = 5,
        [Display(Name = "Cửa hàng đến yêu cầu hủy")]
        OutStoreCancelRequested = 6,
    }

    public enum ProductCategoryType
    {
        [Display(Name = "Sản phẩm")]
        Default = 1,
        [Display(Name = "Phụ thu")]
        Addition = 2,
        [Display(Name = "Phí dịch vụ")]
        RentFee = 3,
        [Display(Name = "Thẻ Nạp Tiền")]
        CardPayment = 4
    }

    public enum StoreTypeEnum
    {
        [Display(Name = "Nhà kho")]
        [Description("Nhà kho")]
        GoodsStore = 0,
        [Display(Name = "Cửa hàng")]
        [Description("Cửa hàng")]
        Hotel = 1,//cửa hàng thuê ngày
        [Display(Name = "Cửa hàng có thuê giờ")]
        [Description("Cửa hàng có thuê giờ")]
        Hostel = 2,//cửa hàng thuê ngày, giờ, qua đêm
        [Display(Name = "Bida/Karaoke")]
        [Description("Bida/Karaoke")]
        StoreWithRoomFee = 3,//Có quản lý chỗ, thu phí
        [Display(Name = "Nhà hàng/Cafe")]
        [Description("Nhà hàng/Cafe")]
        StoreWithRoom = 4,//Có quản lý chỗ, nhưng không thu phí
        [Display(Name = "Cửa hàng/Cafe mang đi")]
        [Description("Cửa hàng/Cafe mang đi")]
        Store = 5,
        [Display(Name = "Tổng đài đặt hàng")]
        [Description("Tổng đài đặt hàng")]
        CallCenter = 6,
        [Display(Name = "Website")]
        [Description("Website")]
        Website = 7
    }


    /// <summary>
    /// Dùng lưu trạng thái của OrderDetail
    /// </summary>
    public enum ProductOrderType
    {
        Single = 0,// Sản phẩm bình thường

        Parent = 1,//Extra product : Cafe sữa + thêm đá (Extra) : 4 ly - Tổng tiền : 300  

        Master = 2,// Extra product: Sản phẩm chính - Cafe sữa: 4 ly - Unit Price: 50 - Total: 200

        Child = 3,//Extra product: Sản phẩm thêm vào - Đá 

        Combo = 4,

        //Báo cáo định lượng: Single + Master + Child + Combo
        //Tong tien hoa don: Single + Parent + Combo

    }

    public enum VoucherCampaignStatus
    {
        [Display(Name = "Chưa khởi động")]
        New = 0,
        [Display(Name = "Đang chạy")]
        Running = 1,
        [Display(Name = "Đã kết thúc")]
        Closed = 2
    }

    public enum VoucherStatus
    {
        [Display(Name = "Chưa bán")]
        New = 0,
        [Display(Name = "Đã bán")]
        Sold = 1,
        [Display(Name = "Đã được sử dụng")]
        Used = 2
    }

    public enum ReceiptType
    {
        [Display(Name = "Nhập Hàng")]
        InInventory = 0,
        [Display(Name = "Nhận Chuyển Kho")]
        InChangeInventory = 1,
        [Display(Name = "Chuyển Kho")]
        OutChangeInventory = 2,
        [Display(Name = "Xuất Trả")]
        OutInventory = 3,
        [Display(Name = "Xuất Bán")]
        SoldProduct = 4,
        [Display(Name = "Xuất Hủy")]
        DraftInventory = 5,

    }

    public enum SourceTypeEnum
    {
        POS = 0,
        FaceBook = 1,
        WebSite = 2,
        CallCenter = 3
    }

    public enum RoomRentMode
    {
        Hour = 1,
        Night = 2,
        Day = 4
    }

    public enum StatusBarCode
    {
        Failed = 0,
        Success = 1
    }

    /// <summary>
    /// IconCategoryEnum is use for render the icon of its Category in the POS machine
    /// - Display Name structure: [fontawesomeicon unnicode + name : 
    /// </summary>
    public enum IconCategoryEnum
    {
        [Display(Name = "&#xf000; Món nước")]
        glass,
        [Display(Name = "&#xf0fc; Bia")]
        beer,
        [Display(Name = "&#xf0f5; Món ăn")]
        cutlery,
        [Display(Name = "&#xf06b; Quà")]
        gift,
    }


    public enum WebSetting
    {
        Title,
        Slogan,
        Description,
        Facebook,
        Twitter,
        Youtube,
        Zalo,

    }
    public enum ProductItemType
    {
        //Nguyên vật liệu
        [Display(Name = "Nguyên vật liệu")]
        Materials = 1,

        [Display(Name = "Vật tư lẻ")]
        MaterialsOrther = 2

    }

    public enum RoleTypeEnum
    {
        [Display(Name = "Quản lý hệ thống")]
        Administrator = 1,
        [Display(Name = "Thu ngân")]
        Reception = 2,
        [Display(Name = "CRM")]
        CRM = 3,
        [Display(Name = "Quản lý cửa hàng")]
        StoreManager = 5,
        [Display(Name = "Đặt hàng")]
        Booking = 6,
        [Display(Name = "Xem báo cáo cửa hàng")]
        StoreReportViewer = 7,
        [Display(Name = "Quản lý")]
        Manager = 8,
        [Display(Name = "Quản lý sản phẩm")]
        ProductManager = 9,
        [Display(Name = "Dọn dẹp")]
        HouseKeeping = 10,
        [Display(Name = "Quản lý kho")]
        Inventory = 11,
        [Display(Name = "Quản lý thương hiệu")]
        BrandManager = 12,
        [Display(Name = "Active User")]
        ActiveUser = 4,
        [Display(Name = "Nhân viên")]
        Employee = 13,
        [Display(Name = "Phân công ca làm")]
        ShiftCreator = 14,
        [Display(Name = "Chỉnh sửa ca làm")]
        ShiftEditor = 15,
        [Display(Name = "Danh sách ca làm")]
        ShiftBrowser = 16,
        [Display(Name = "Người dùng Mobile")]
        MobileUser = 17,
    }



    /// <summary>
    /// Quy tắc áp dụng:
    ///     1. OrderDetail:
    ///         + Chỉ được áp dụng 1 Promotion level OrderDetail cho 1 OrderEditViewModel  detail
    ///     2. Order
    ///         + Mỗi Group trong Promotion chỉ được apply 1 lần 
    /// </summary>
    public enum PromotionApplyLevelEnum
    {
        [Display(Name = "Hóa đơn")]
        Order = 0,

        [Display(Name = "Sản phẩm")]
        OrderDetail = 1
    }

    /// <summary>
    /// PromotionType
    /// --------------------------------------
    /// 0. Internal: Khuyến mãi trực tiếp của cửa hàng quy định
    /// 1. Separate: Khuyến mãi theo event, chỉ áp dụng 1 lần 1 loại
    /// 2. Common: Khuyến mãi thông thường
    /// --------------------------------------
    /// Có thể áp dụng nhiều Common chung với nhau
    /// Chỉ áp dụng được 1 loại Separate, không áp dụng chung với Common
    /// Có thể áp dụng Internal với tất cả
    /// </summary>
    public enum PromotionTypeEnum
    {
        [Display(Name = "Khuyến mãi cửa hàng")]
        Internal = 0,
        [Display(Name = "Khuyến mãi event")]
        Separate = 1,
        [Display(Name = "Khuyến mãi thông thường")]
        Common = 2,
        [Display(Name = "Khuyến mãi ký Bill")]
        Bill = 3
    }

    /// <summary>
    /// GiftType 
    /// --------------------------------------
    /// 0. DiscountRate:        RATE > 0    AMOUNT > 0
    /// 1. Gift:                RATE = 0    AMOUNT = 0      
    /// 2. DiscountAmount:      RATE = 0    AMOUNT > 0      
    /// </summary>
    public enum PromotionGiftTypeEnum
    {
        DiscountRate = 0,
        Gift = 1,
        DiscountAmount = 2
    }

    /// <summary>
    /// Type
    /// --------------------------------------
    /// </summary>
    public enum PaymentTypeEnum
    {
        [Display(Name = "Tiền mặt")]
        Cash = 1,
        [Display(Name = "Thẻ")]
        Card = 2,
        [Display(Name = "Thẻ thành viên")]
        MemberPayment = 3,
        [Display(Name = "Voucher")]
        Voucher = 4,
        [Display(Name = "Tài khoản khách hàng")]
        AccountReceivable = 5,
        [Display(Name = "Khác")]
        Other = 6,
        [Display(Name = "MasterCard")]
        MasterCard = 7,
        [Display(Name = "VisaCard")]
        VisaCard = 8,
        [Display(Name = "Tiền thối")]
        ExchangeCash = 9,
        [Display(Name = "Tiền nạp vào tài khoản")]
        PaymentMember = 10,
        [Display(Name = "Khách nợ")]
        Debt = 11,
        [Display(Name = "Trả nợ")]
        PayDebt = 12,
    }

    public enum ImageCssEnum
    {

        // tạm
        [Display(Name = "&#xf000; Món nước")]
        glass,
        [Display(Name = "&#xf0fc; Bia")]
        beer,
        [Display(Name = "&#xf0f5; Món ăn")]
        cutlery,
        [Display(Name = "Quà")]
        gift,
        [Display(Name = "Giảm giá")]
        percent
    }


    public enum ProductColorGroup
    {
        [Display(Name = "Xanh dương")]
        Blue = 0,
        [Display(Name = "Đỏ")]
        Red = 1,
        [Display(Name = "Xanh lá")]
        Green = 2,
    }

    public enum ProductGroup
    {
        [Display(Name = "Ly lạnh")]
        Cold = 0,
        [Display(Name = "Ly nóng")]
        Hot = 1,
        [Display(Name = "Ly khác")]
        Other = 2,
    }

    public enum PaymentMethod
    {
        [Display(Name = "Tiền mặt")]
        Cash = 1,
        [Display(Name = "Thẻ tín dụng")]
        Card = 2,
    }

    ///// <summary>
    ///// --------------------------------------
    ///// 0. CreditCard: Thanh toán tiền mặt khi mua hàng
    ///// 1. GiftCard: Mua sản phẩm dựa trên thẻ
    ///// 2. PointCard: Tích điểm vào tài khoản
    ///// --------------------------------------
    ///// 
    ///// 
    ///// 
    ///// </summary>
    //public enum MembershipCardTypeEnum
    //{
    //    [Display(Name = "Thẻ thanh toán")]
    //    CreditCard = 0,
    //    [Display(Name = "Thẻ sản phẩm")]
    //    GiftCard = 1,
    //    [Display(Name = "Thẻ tích điểm")]
    //    PointCard = 2
    //}

    /// <summary>
    /// --------------------------------------
    /// 1. CreditAccount: Tài khoản trừ tiền khi thanh toán
    /// 2. GiftAccount: Tài khoản trừ số lượng sản phẩm khi thanh toán
    /// 3. PointAccount: Tài khoản + điểm khi mua hàng
    /// --------------------------------------
    /// 
    /// 
    /// 
    /// </summary>
    public enum AccountTypeEnum
    {
        [Display(Name = "Tài khoản thanh toán")]
        CreditAccount = 1,
        [Display(Name = "Tài khoản sản phẩm")]
        GiftAccount = 2,
        [Display(Name = "Tài khoản tích điểm")]
        PointAccount = 3
    }

    /// <summary>
    /// --------------------------------------
    /// 1. Copper: Thẻ Đồng
    /// 2. Silver: Thẻ Bạc
    /// 3. Gold: Thẻ Vàng
    /// --------------------------------------
    /// 
    /// 
    /// 
    /// </summary>
    public enum MembershipCardLevel
    {
        [Display(Name = "Thẻ Đồng")]
        Copper = 0,
        [Display(Name = "Thẻ Bạc")]
        Silver = 1,
        [Display(Name = "Thẻ Vàng")]
        Gold = 2,
    }
    public enum MembershipCardLevelPoint
    {
        LevelCopper = 0,
        LevelSilver = 100,
        LevelGold = 200,
    }

    public enum TransactionStatus
    {
        [Display(Name = "Mới")]
        New = 0,
        [Display(Name = "Đã duyệt")]
        Approve = 1,
        [Display(Name = "Đã hủy")]
        Cancel = 2,
    }

    public enum TransactionAmount
    {
        [Display(Name = "100,000 VNĐ")]
        VND100 = 100000,
        [Display(Name = "200,000 VNĐ")]
        VND200 = 200000,
        [Display(Name = "300,000 VNĐ")]
        VND300 = 300000,
        [Display(Name = "500,000 VNĐ")]
        VND500 = 500000
    }

    public enum TransactionTypeEnum
    {
        [Display(Name = "Default")]
        Default = 1,
        [Display(Name = "Rollback")]
        RollBack = 2,
        [Display(Name = "ActiveCard")]
        ActiveCard = 3,
    }

    public enum MenuTypeEnum
    {
        All = 0,
        BrandMenu = 1,
        StoreMenu = 2,
    }
    public enum ElementTypeTemplate
    {
        [Display(Name = "Header")]
        Header = 1,
        [Display(Name = "Footer")]
        Footer = 2,
        [Display(Name = "FrontMenu")]
        FrontMenu = 3,
        [Display(Name = "BackMenu")]
        BackMenu = 4,
        [Display(Name = "LeftMenu")]
        LeftMenu = 5,
        [Display(Name = "RightMenu")]
        RightMenu = 6,
        [Display(Name = "Other")]
        Other = 7,
    }

    //public enum ProcessStatusAttendance
    //{
    //    [Display(Name = "NotUpdate")]
    //    NotUpdate=0,
    //    [Display(Name = "UpdatedByAuto")]
    //    UpdatedByAuto = 1,
    //    [Display(Name = "UpdatedByManualCanOveride")]
    //    UpdatedByManualCanOveride = 2,
    //    [Display(Name = "UpdatedByManualCanNotOveride")]
    //    UpdatedByManualCanNotOveride = 3
    //}

    //public enum StatusAttendance
    //{
    //    [Display(Name = "Đã duyệt")]
    //    Assigned = 0,
    //    [Display(Name = "Đã Hủy")]
    //    Canceled = 1,
    //    [Display(Name = "Chờ duyệt")]
    //    WaitAssign = 2
    //}

    public enum ProcessingStatusAttendenceEnum
    {
        [Display(Name = "Assign")]
        Assign = 0,
        [Display(Name = "UpdatedByAuto")]
        UpdatedByAuto = 1,
        [Display(Name = "UpdatedByManualCanOveride")]
        UpdatedByManualCanOveride = 2,
        [Display(Name = "UpdatedByManualCanNotOveride")]
        UpdatedByManualCanNotOveride = 3,
        [Display(Name = "UpdatedByCheckContinueAuto")]
        UpdatedByCheckContinueAuto = 5,
        //Nhân viên chưa được assign vào ca, được hệ thống phát hiện
        [Display(Name = "UpdateByAutoWithoutAssign")]
        UpdateByAutoWithoutAssign = 6,
        //Nhân viên không phải cửa hàng điểm danh tại ca, được hệ thống phát hiện
        [Display(Name = "UpdateByAutoWithoutAssignOtherStore")]
        UpdateByAutoWithoutAssignOtherStore = 7,
    }

    public enum StatusAttendanceEnum
    {
        [Display(Name = "Processing")]
        Processing = 0,
        [Display(Name = "Approved")]
        Approved = 1,
        [Display(Name = "Reject")]
        Reject = 2,
    }

    public enum MachineType
    {
        [Display(Name = "RonaldJack")]
        RonaldJack = 0,
        [Display(Name = "Hip")]
        Hip = 1,

    }
    public enum AreaTypeEnum
    {
        Province = 1,
        District = 2,
    }
    public enum Sex
    {
        [Display(Name = "Male")]
        Male = 0,
        [Display(Name = "Female")]
        Female = 1,
        [Display(Name = "Other")]
        Other = 2,
    }

}

