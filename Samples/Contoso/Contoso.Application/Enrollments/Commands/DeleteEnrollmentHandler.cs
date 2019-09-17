﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Contoso.Core;
using Contoso.Core.Domain;
using Contoso.Core.Interfaces.Repositories;
using LanguageExt;
using MediatR;

namespace Contoso.Application.Enrollments.Commands
{
    public class DeleteEnrollmentHandler : IRequestHandler<DeleteEnrollment, Validation<Error, Task>>
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public DeleteEnrollmentHandler(IEnrollmentRepository enrollmentRepository) => _enrollmentRepository = enrollmentRepository;

        public async Task<Validation<Error, Task>> Handle(DeleteEnrollment request, CancellationToken cancellationToken) => 
            (await Find(request.EnrollmentId))
                .ToValidation<Error>($"Enrollment Id {request.EnrollmentId} does not exist")
                .Map(Delete);

        private Task Delete(Enrollment e) => _enrollmentRepository.Delete(e.EnrollmentId);

        private Task<Option<Enrollment>> Find(int id) => _enrollmentRepository.Get(id);
    }
}
