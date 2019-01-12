using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CG.Services;
using DB.DataAccess.Infrastructure;
using DB.Entity;
using DB.Entity.ServiceResp;
using DB.Repo;
using Microsoft.Extensions.Logging;

namespace DB.Services
{
    public class TestimonialService : ITestimonialService
    {
        public ServiceResponse<IQueryable<Testimonial>> GetAll(FilterReq req)
        {
            try
            {
                var qry = _repository.TableNoTracking;
                if (!string.IsNullOrWhiteSpace(req.Filter))
                {
                    qry = qry.Where(p => p.Title.Contains(req.Filter));
                }

                return new ServiceResponse<IQueryable<Testimonial>>(true)
                {
                    Data = qry,
                    Messages = new List<Messages> { AppMessages.DataRetrievedSuccessfully }
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToExceptionMessage()?.Message);
                return new ServiceResponse<IQueryable<Testimonial>>(false, new List<Messages> { AppMessages.TechincalProblemOccured },MessageType.Danger);
            }
        }

       
        private bool IsExists(Testimonial model)
        {

            return _repository.Table.Any(x =>
                x.Id != model.Id && x.Title == model.Title);

        }
        public async Task<ServiceResponse<Testimonial>> CreateAsync(Testimonial entity)
        {
            if (IsExists(entity))
            {
                return new ServiceResponse<Testimonial>(false, new List<Messages> { AppMessages.DataAlreadyExist });
            }
            try
            {
                entity.CreatedBy = _webHelper.CurrentUser;
                entity.CreatedDate = _webHelper.CurrentDateUtc;
                entity.IpAddress = _webHelper.GetCurrentIpAddress();
                _repository.Add(entity);
                await _unitOfWork.CommitAsync();

                //if (!string.IsNullOrEmpty(entity.ImageName))
                //{
                //    entity.ImageName = entity.Id + entity.ImageName;
                //    _unitOfWork.Commit();
                //    entity.ImageName = entity.ImageName;
                //}
                return new ServiceResponse<Testimonial>(true)
                {
                    Messages = new List<Messages> { AppMessages.DataSavedSuccessfully }
                };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToExceptionMessage()?.Message);
                return new ServiceResponse<Testimonial>(false, new List<Messages> { AppMessages.TechincalProblemOccured }, MessageType.Danger);
            }
        }

        public async Task<ServiceResponse<Testimonial>> EditAsync(Testimonial entity)
        {
            if (IsExists(entity))
            {
                return new ServiceResponse<Testimonial>(false, new List<Messages> { AppMessages.DataAlreadyExist });
            }
            try
            {

                entity.ModifiedBy = _webHelper.CurrentUser;
                entity.ModifiedDate = _webHelper.CurrentDateUtc;
                entity.IpAddress = _webHelper.GetCurrentIpAddress();
                _repository.Update(entity);
                await _unitOfWork.CommitAsync();
                return new ServiceResponse<Testimonial>(true) { Messages = new List<Messages> { AppMessages.DataupdatedSuccessfully } };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToExceptionMessage()?.Message);
                return new ServiceResponse<Testimonial>(false, new List<Messages> { AppMessages.TechincalProblemOccured }, MessageType.Danger);
            }
        }

        public ServiceResponse<Testimonial> Detail(int id)
        {
            try
            {
                var data = _repository.GetById(id);
                return new ServiceResponse<Testimonial>(true)
                {
                    Data = data,
                    Messages = new List<Messages> { AppMessages.DataupdatedSuccessfully }
                };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToExceptionMessage()?.Message);
                return new ServiceResponse<Testimonial>(false, new List<Messages> { AppMessages.TechincalProblemOccured }, MessageType.Danger);
            }
        }

        public async Task<ServiceResponse> DeleteAsync(int id)
        {
            if (id == default(int))
            {
                return new ServiceResponse(false, new List<Messages> { AppMessages.DataNotFound });
            }
            try
            {
                var data = _repository.Table.FirstOrDefault(x=>x.Id==id);
                if (data == null)
                {
                    return new ServiceResponse(false, new List<Messages> { AppMessages.DataNotFound });
                }

                _repository.Delete(data);
                await _unitOfWork.CommitAsync();
                return new ServiceResponse(true) { Messages = new List<Messages> { AppMessages.DataDeletedSuccessfully } };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToExceptionMessage()?.Message);
                return new ServiceResponse(false, new List<Messages> { AppMessages.TechincalProblemOccured }, MessageType.Danger);

            }
        }

        private readonly ITestimonialRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IWebHelper _webHelper;
        public TestimonialService(ITestimonialRepository repository, ILoggerFactory loggerFactory,
         IUnitOfWork unitOfWork, IWebHelper webHelper)
        {
            _logger = loggerFactory.CreateLogger("TestimonialService");
            _repository = repository;
            _unitOfWork = unitOfWork;
            _webHelper = webHelper;
        }
    }
}
