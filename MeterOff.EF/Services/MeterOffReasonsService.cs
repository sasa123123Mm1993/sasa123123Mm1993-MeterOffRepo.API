using Humanizer;
using MeterOff.Core.Interfaces;
using MeterOff.Core.Models.Base;
using MeterOff.Core.Models.Base_Response.Providers;
using MeterOff.Core.Models.Dto.CMaintenenceMetersOff;
using MeterOff.Core.Models.Dto.MeterOffReasons;
using MeterOff.Core.Models.Exception;
using MeterOff.Core.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.EF.Services
{
    public class MeterOffReasonsService : IMeterOffReasonsRepository
    {
        private readonly DBContext _context;

        public MeterOffReasonsService(DBContext context)
        {
            _context = context;
        }

        public Response<CUploadMainteneceMetersOffReason> Add(CUploadMainteneceMetersOffReason cuploadMeterOffReasonsOutput)
        {
            Response<CUploadMainteneceMetersOffReason> response = new Response<CUploadMainteneceMetersOffReason>();
            try
            {
                var resultOfValidation = ValidateAddReason(cuploadMeterOffReasonsOutput);
                if (resultOfValidation != null)
                {
                    var model = new CUploadMainteneceMetersOffReason
                    {
                        Code = cuploadMeterOffReasonsOutput.Code,
                        CreationTime = DateTime.Now,
                        CreatorById = 1,
                        IsDeleted = false,
                        Name = cuploadMeterOffReasonsOutput.Name,
                        Note = cuploadMeterOffReasonsOutput.Note,
                    };
                    var result = _context.AddAsync(model);
                    var ISSaved = Save() > 0;
                    if (ISSaved)
                    {
                        response.code = Added.Code;
                        response.payload = model;
                        response.status = Added.Status;
                        response.message = Added.messageAr;
                        return response;
                    }
                }

                else
                {
                    response.code = Failed.Code;
                    response.message = Failed.messageEn;
                    response.status = Failed.Status;
                    response.payload = null;
                    return response;
                }
                response.code = Failed.Code;
                response.message = Failed.messageEn;
                response.status = Failed.Status;
                response.payload = null;
                return response;
            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = null;
                return response;
            }
           
        }

        public Response<CUploadMainteneceMetersOffReason> Update(int id, CUploadMainteneceMetersOffReason cuploadMeterOffReasonsOutput)
        {
            Response<CUploadMainteneceMetersOffReason> response = new Response<CUploadMainteneceMetersOffReason>();
            try
            {
                var result = ValidateUpdateReason(cuploadMeterOffReasonsOutput);
                
                var reason = _context.CUploadMainteneceMetersOffReason.FirstOrDefault(r => r.IsDeleted != true && r.Id == id);
                if (reason == null)
                {
                    response.status = Failed.Status;
                    response.code = Empty.Code;
                    response.message = "سبب العطل غير موجود بالنظام";
                    response.status = Failed.Status;
                    return response;
                }

                else
                {
                    reason.Code = cuploadMeterOffReasonsOutput.Code;
                    reason.Name = cuploadMeterOffReasonsOutput.Name;
                    reason.Note = cuploadMeterOffReasonsOutput.Note;
                    reason.CreatorById = 1;
                    reason.IsDeleted = false;
                    reason.ModificationTime = DateTime.Now;
                    reason.ModifiedById = 1;
                    reason.Id = id;
                    _context.Update(reason);
                    var ISSaved = Save() > 0;
                    if (ISSaved)
                    {
                        response.code = Updated.Code;
                        response.payload = reason;
                        response.status = Updated.Status;
                        response.message = Updated.messageAr;
                        return response;
                    }
                }

            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = null;
                return response;
            }

            response.code = Failed.Code;
            response.message = Failed.messageEn;
            response.status = Failed.Status;
            response.payload = null;
            return response;
        }


        public Response<bool> Delete(int id)
        {
            Response<bool> response = new Response<bool>();
            try
            {
                var reason = _context.CUploadMainteneceMetersOffReason.FirstOrDefault(r => r.IsDeleted != true && r.Id == id);
                if (reason == null)
                {
                    response.code = Empty.Code;
                    response.message = "لا يوجد سبب لهذا العطل";
                    response.status = Empty.Status;
                    response.payload = false;
                    return response;
                }
                else
                {
                    reason.IsDeleted = true;
                    _context.Update(reason);
                    var ISSaved = Save() > 0;
                    if (ISSaved)
                    {
                        response.code = DeleteSuccess.Code;
                        response.payload = ISSaved;
                        response.status = DeleteSuccess.Status;
                        response.message = DeleteSuccess.messageAr;
                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = false;
                return response;
            }

            response.code = Failed.Code;
            response.message = "حدث خطا أثناء حذف معلومات العميل";
            response.status = Failed.Status;
            response.payload = false;
            return response;
        }
        public Response<List<CUploadMainteneceMetersOffReason>> GetAll()
        {
            Response<List<CUploadMainteneceMetersOffReason>> response = new Response<List<CUploadMainteneceMetersOffReason>>();
            try
            {
                var reasons = _context.CUploadMainteneceMetersOffReason.Where(r=>r.IsDeleted !=true).ToList();
                if (reasons != null && reasons.Any())
                {
                    response.payload = reasons;
                    response.code = Success.Code;
                    response.status = Success.Status;
                    response.message = Success.messageAr;
                    return response;
                }
                response.code = Failed.Code;
                response.message = Failed.messageEn;
                response.status = Failed.Status;
                response.payload = null;
                return response;
            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = null;
                return response;
            }

        }
        public Response<CUploadMainteneceMetersOffReason> GetByCode(int code)
        {
            Response<CUploadMainteneceMetersOffReason> response = new Response<CUploadMainteneceMetersOffReason>();
            try
            {
                var reason = _context.CUploadMainteneceMetersOffReason.FirstOrDefault(r=>r.IsDeleted != true && r.Code == code);
                if (reason != null)
                {
                    response.payload = reason;
                    response.code = Success.Code;
                    response.status = Success.Status;
                    response.message = Success.messageAr;
                    return response;
                }
                response.code = Empty.Code;
                response.message = Empty.messageAr;
                response.status = Empty.Status;
                return  response;
            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = null;
                return response;
            }
        }
        public Response<CUploadMainteneceMetersOffReason> GetById(int id)
        {
            Response<CUploadMainteneceMetersOffReason> response = new Response<CUploadMainteneceMetersOffReason>();
            try
            {
                var reason = _context.CUploadMainteneceMetersOffReason.FirstOrDefault(r => r.IsDeleted != true && r.Id == id);
                if (reason != null)
                {
                    response.payload = reason;
                    response.code = Success.Code;
                    response.status = Success.Status;
                    response.message = Success.messageAr;
                    return response;
                }
                response.code = Empty.Code;
                response.message = Empty.messageAr;
                response.status = Empty.Status;
                return response;
            }
            catch (Exception ex)
            {
                response.code = GeneralException.Code;
                response.message = GeneralException.messageAr;
                response.status = ex.Message;
                response.payload = null;
                return response;
            }
        }
        
        
        public Response<string> ValidateAddReason(CUploadMainteneceMetersOffReason model)
        {
            Response<string> response = new Response<string>
            {
                code = Empty.Code,
                status = Empty.Status
            };

            var reason = _context.CUploadMainteneceMetersOffReason.FirstOrDefault(r => r.IsDeleted != true && r.Code == model.Code);
            if (reason != null)
            {
                response.status = Failed.Status;
                response.code = Failed.Code;
                response.message = "سبب العطل موجود بالفعل";
                response.payload = "";
                return response;
            }
            if (model.Code == null)
            {
                response.status = Failed.Status;
                response.code = Failed.Code;
                response.message = "يجب ادخال كود لسبب العطل";
                response.payload = Failed.messageEn;
                return response;
            }

            if (model.Name == null)
            {
                response.status = Failed.Status;
                response.code = Failed.Code;
                response.message = "يجب ادخال سبب للعطل";
                response.payload = Failed.messageEn;
                return response;
            }

            return response;
        }
        public Response<string> ValidateUpdateReason(CUploadMainteneceMetersOffReason model)
        {
            Response<string> response = new Response<string>
            {
                code = Empty.Code,
                status = Empty.Status
            };

            if (model.Code == null)
            {
                response.status = Failed.Status;
                response.code = Failed.Code;
                response.message = "يجب ادخال كود لسبب العطل";
                response.payload = Failed.messageEn;
                return response;
            }

            if (model.Name == null)
            {
                response.status = Failed.Status;
                response.code = Failed.Code;
                response.message = "يجب ادخال سبب للعطل";
                response.payload = Failed.messageEn;
                return response;
            }

            return response;
        }



        //public async Task<CUploadMainteneceMetersOffReason> Add(CUploadMainteneceMetersOffReason cuploadMeterOffReasonsOutput)
        //{
        //    Response<string> response = new Response<string>();

        //    await _context.AddAsync(cuploadMeterOffReasonsOutput);
        //    _context.SaveChanges();

        //    return cuploadMeterOffReasonsOutput;

        //}

        //public CUploadMainteneceMetersOffReason Delete(CUploadMainteneceMetersOffReason cuploadMeterOffReasonsOutput)
        //{

        //    cuploadMeterOffReasonsOutput.IsDeleted = true;
        //    _context.Update(cuploadMeterOffReasonsOutput);
        //    //_context.Remove(cuploadMeterOffReasonsOutput);
        //    _context.SaveChanges();

        //    return cuploadMeterOffReasonsOutput;
        //}

        //public IEnumerable<CUploadMainteneceMetersOffReason> GetAll()
        //{
        //    var m = _context.CUploadMainteneceMetersOffReason.ToList();
        //    //var aa = await _context.CUploadMainteneceMetersOffReason.ToListAsync();
        //    return m;

        //}

        //public async Task<CUploadMainteneceMetersOffReason> GetByCode(int Code)
        //{
        //    var model = _context.CUploadMainteneceMetersOffReason.SingleOrDefault(m => m.Code == Code);
        //    return model;

        //}

        //public async Task<CUploadMainteneceMetersOffReason> GetById(int id)
        //{
        //    var model = _context.CUploadMainteneceMetersOffReason.SingleOrDefault(m => m.Id == id);
        //    return model;
        //}

        //public CUploadMainteneceMetersOffReason Update(CUploadMainteneceMetersOffReason cuploadMeterOffReasonsOutput)
        //{
        //    _context.Update(cuploadMeterOffReasonsOutput);
        //    _context.SaveChanges();

        //    return cuploadMeterOffReasonsOutput;
        //}

        //public bool IsvalidCUploadMainteneceMetersOffReason(int? uploadReasonId)
        //{
        //    var isFound = _context.CUploadMainteneceMetersOffReason.Any(g => g.Id == uploadReasonId);
        //    return isFound;
        //}

        

        

        public Response<string> ValidateAddReason(InsertCUploadMainteneceMetersOffReasonInput data)
        {
            throw new NotImplementedException();
        }

        public Response<string> ValidateUpdateReason(InsertCUploadMainteneceMetersOffReasonInput data)
        {
            throw new NotImplementedException();
        }

        public bool IsvalidCUploadMainteneceMetersOffReason(int? uploadReasonId)
        {
            var isFound = _context.CUploadMainteneceMetersOffReason.Any(g => g.Id == uploadReasonId);
            return isFound;
        }
        public int SaveArchive()
        {
            int status = -1;
            try { status = _context.SaveChanges(); }
            catch (Exception ex) { }
            return status;
        }

        public int Save()
        {
            int status = -1;
            try { status = _context.SaveChanges(); }
            catch (Exception ex) { }
            return status;
        }

    }
}
