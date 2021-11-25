using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using _0_Framework.Application;
using _0_FrameWork.Infrasutructure;

namespace CommentManagement.Infrastructure.EFCore.Repository
{
    public class CommentRepository : RepositoryBase<long, Comment>, ICommentRepository
    {
        private readonly CommentContext _contex;

        public CommentRepository(ShopContext contex) : base(contex)
        {
            _contex = contex;
        }

        public List<CommentViewModel> Search(CommentSearchModel searchModel)
        {
            var query=_contex.Comments
            .Select(x=> new CommentViewModel
            { 
                Id=x.Id,
                Name=x.Name,
                Type=x.Type,
                Email=x.Email,
                Message=x.Message,
                Website=x.Website,
                OwnerName=x.OwnerName,
                IsCanceled=x.IsCanceled,
                IsConfirmed=x.IsConfirmed,
                OwnerRecordId=x.OwnerRecordId,
                CommentDate=x.CreationDate.ToFarsi()
            });

            if(!string.IsNullOrWhiteSpace(searchModel.Name))
                query=query.Where(x=>x.Name.Contains(searchModel.Name));

            if(!string.IsNullOrWhiteSpace(searchModel.Email))
                query=query.Where(x=>x.Email.Contains(searchModel.Email));

                return query.OrderByDescending(x=>x.Id).ToList();
        }
    }
}