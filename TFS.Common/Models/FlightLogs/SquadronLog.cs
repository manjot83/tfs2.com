﻿using System.ComponentModel.DataAnnotations;
using TFS.Models;
using TFS.Models.PersonnelRecords;
using System;

namespace TFS.Models.FlightLogs
{
    public class SquadronLog : BaseDomainObject
    {
        public SquadronLog()
        {
            // Some domain specific defaults
            FlyingUnit = "TFS";
        }

        public virtual Guid? Id { get; set; }

        public virtual FlightLog FlightLog { get; set; }

        public virtual string FlyingUnit { get; set; }

        public virtual Person Person { get; set; }
        [DomainEquality, Required]
        public virtual DutyCode DutyCode { get; set; }

        [DomainEquality, Required]
        public virtual double PrimaryHours { get; set; }
        [DomainEquality, Required]
        public virtual double SecondaryHours { get; set; }
        [DomainEquality, Required]
        public virtual double InstructorHours { get; set; }
        [DomainEquality, Required]
        public virtual double EvaluatorHours { get; set; }
        [DomainEquality, Required]
        public virtual double OtherHours { get; set; }
        [DomainEquality, Required]
        public virtual int Sorties { get; set; }
        [DomainEquality, Required]
        public virtual double PrimaryNightHours { get; set; }
        [DomainEquality, Required]
        public virtual double PrimaryInstrumentHours { get; set; }
        [DomainEquality, Required]
        public virtual double SimulatedInstrumentHours { get; set; }

        public virtual double CalculateTotalHours()
        {
            return PrimaryHours +
                   SecondaryHours +
                   InstructorHours +
                   EvaluatorHours +
                   OtherHours;
        }

        public virtual void MarkedUpdated()
        {
            FlightLog.MarkedUpdated();
        }
    }
}
