using TailoringApp.Dto;
using TailoringApp.Entity;
using TailoringApp.Identity;
using TailoringApp.Interface.IRepository;
using TailoringApp.Interface.IService;

namespace TailoringApp.Implementation.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ILocationRepository _locationRepository;
        public CustomerService(ICustomerRepository customerRepository, IUserRepository userRepository, IRoleRepository roleRepository, ILocationRepository locationRepository)
        {
            _customerRepository = customerRepository;
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _locationRepository = locationRepository;
        }

        public async Task<BaseResponse<CustomerDto>> Create(CustomerRequestModel model)
        {
            var customer = await _customerRepository.GetAsync(x => x.User.Email == model.Email);
            if (customer != null)
            {
                return new BaseResponse<CustomerDto>
                {
                    Message = "email already exist",
                    Status = false
                };
            }
            var user = new User
            {
                Email = model.Email,
                Password = model.Password,

            };
            var role = await _roleRepository.GetAsync(x => x.Name == "Customer");
            var userRole = new UserRole
            {
                User = user,
                UserId = user.Id,
                Role = role,
                RoleId = role.Id
            };
            user.UserRoles.Add(userRole);
            var location = new Location
            {
                Country = model.Country,
                State = model.State,
                Area = model.Area,
            };

            var createLocation = await _locationRepository.Create(location);
            var customers = new Customer
            {
                LocationId = createLocation.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                User = user,
                UserId = user.Id
            };
            
            await _userRepository.Create(user);
            var customerss = await _customerRepository.Create(customers);
            return new BaseResponse<CustomerDto>
            {
                Message = "success",
                Status = true,
                Data = new CustomerDto
                {
                    Id = customerss.Id,
                    FirstName = customerss.FirstName,
                    LastName = customerss.LastName,
                    PhoneNumber = customerss.PhoneNumber,
                    Email = customerss.User.Email,
                }
            };
        }

        public async Task<BaseResponse<CustomerDto>> Get(int id)
        {
            var getCustomer = await _customerRepository.GetAsync(id);
            if (getCustomer == null)
            {
                return new BaseResponse<CustomerDto>
                {
                    Message = "failed",
                    Status = false,
                };
            }
            return new BaseResponse<CustomerDto>
            {
                Data = new CustomerDto
                {
                    Id = getCustomer.Id,
                    Email = getCustomer.User.Email,
                    FirstName = getCustomer.FirstName,
                    LastName = getCustomer.LastName,
                    PhoneNumber = getCustomer.PhoneNumber,
                }
            };
        }

        public async Task<BaseResponse<IEnumerable<CustomerDto>>> GetAll()
        {
            var getAll = await _customerRepository.GetAllAsync();
            if (getAll == null)
            {
                return new BaseResponse<IEnumerable<CustomerDto>>
                {
                    Message = "failed",
                    Status = false,
                };
            }
            var getAllCustomer = getAll.ToList().Select(a => new CustomerDto
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
                PhoneNumber = a.PhoneNumber,
                Email = a.User.Email,
            });
            return new BaseResponse<IEnumerable<CustomerDto>>
            {
                Data = getAllCustomer,
                Message = "success",
                Status = true,
            };
        }
    }
}
