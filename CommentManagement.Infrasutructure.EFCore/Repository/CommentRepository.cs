using System.Collections.Generic;
using System.Linq;
using _0_FrameWork.Application;
using _0_FrameWork.Infrasutructure;
using CommentManagement.Application.Contracts.Comment;
using CommentManagement.Domain.CommentAgg;

namespace CommentManagement.Infrasutructure.EFCore.Repository
{
    public class CommentRepository : RepositoryBase<long, Comment>, ICommentRepository
    {
        private readonly CommentContext _contex;

        public CommentRepository(CommentContext contex) : base(contex)
        {
            _contex = contex;
        }

        public List<CommentViewModel> Search(CommentSearchModel searchModel)
        {
            var query = _contex.Comments
                .Select(x => new CommentViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Website = x.Website,
                    Message = x.Message,
                    OwnerRecordId = x.OwnerRecordId,
                    Type = x.Type,
                    IsCanceled = x.IsCanceled,
                    IsConfirmed = x.IsConfirmed,
                    CommentDate = x.CreationDate.ToFarsi()
                });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            if (!string.IsNullOrWhiteSpace(searchModel.Email))
                query = query.Where(x => x.Email.Contains(searchModel.Email));

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}