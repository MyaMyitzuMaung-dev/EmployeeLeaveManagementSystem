namespace IPB2.EmployeeLeaveMS.WebApi.Features.Employees;

public class EmployeeCreateRequestModel
{
    public string EmployeeCode { get; set; }
    public string EmployeeName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Department { get; set; }
    public string Position { get; set; }
    public DateOnly JoinDate { get; set; }
}

public class EmployeeCreateResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public int EmployeeId { get; set; }
}

public class EmployeeEditRequestModel
{
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Department { get; set; }
    public string Position { get; set; }
}

public class EmployeeEditResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
}

public class EmployeeDeleteRequestModel
{
    public int EmployeeId { get; set; }
}

public class EmployeeDeleteResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
}

public class EmployeeDto
{
    public int EmployeeId { get; set; }
    public string EmployeeCode { get; set; }
    public string EmployeeName { get; set; }
    public string Department { get; set; }
    public string Position { get; set; }
}

public class EmployeeDetailRequestModel
{
    public int EmployeeId { get; set; }
}

public class EmployeeDetailResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }

    public int EmployeeId { get; set; }
    public string EmployeeCode { get; set; }
    public string EmployeeName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Department { get; set; }
    public string Position { get; set; }
    public DateOnly JoinDate { get; set; }
}
public class EmployeeListRequestModel
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
public class EmployeeListResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }

    public int TotalCount { get; set; }

    public List<EmployeeDto> Employees { get; set; }
}

