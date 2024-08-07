// Copyright (c) 2024 - Jun Dev. All rights reserved

import { addDays, addMonths, addYears, format } from 'date-fns';

export const datePattern = Object.freeze({
  shortDate: 'dd/MM/yyyy',
  fullDate: 'dd/MM/yyyy hh:mm:ss',
  fullDateNotSecond: 'dd/MM/yyyy hh:mm',
  fullTime: 'hh:mm:ss',
  shortTime: 'hh:mm',
});

// Get date
export const getShortDate = (date: string | Date) =>
  format(date, datePattern.shortDate);
export const getDate = (date: string | Date) =>
  format(date, datePattern.fullDateNotSecond);
export const getFullDate = (date: string) => format(date, datePattern.fullDate);

// Get time
export const getFullTime = (date: string | Date) => format(date, datePattern.fullTime);
export const getShortTime = (date: string | Date) => format(date, datePattern.shortTime);

// Date time utility
export const getDateTime = function (date = null) {
  let dateForHandle = new Date();
  if (date !== null) {
    dateForHandle = new Date(date);
  }

  return {
    currentDate: dateForHandle,
    addDays: function (day: number) {
      this.currentDate = addDays(this.currentDate, day);
      return this;
    },
    addMonths: function (months: number) {
      this.currentDate = addMonths(this.currentDate, months);
      return this;
    },
    addYears: function (years: number) {
      this.currentDate = addYears(this.currentDate, years);
      return this;
    },
  };
};
