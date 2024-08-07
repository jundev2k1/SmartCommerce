// Copyright (c) 2024 - Jun Dev. All rights reserved

import * as React from 'react';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select, { SelectChangeEvent } from '@mui/material/Select';
import { SelectListItem } from './common';

interface SelectSingleProps
  extends React.SelectHTMLAttributes<HTMLSelectElement> {
  label: string;
  items: SelectListItem[];
  defaultSelect: string | undefined;
  isAutoWidth: boolean;
}

const SelectSingleInput = (props: SelectSingleProps) => {
  const { id, label, items, defaultSelect, isAutoWidth = false } = props;
  const [selectValue, setSelectValue] = React.useState(defaultSelect);

  const handleChangeValue = (event: SelectChangeEvent) => {
    const { value } = event.target;
    setSelectValue(value);
  };

  return (
    <FormControl fullWidth>
      <InputLabel id={id}>{label}</InputLabel>
      <Select
        labelId={id}
        id="demo-simple-select"
        value={selectValue}
        label={label}
        onChange={handleChangeValue}
        autoWidth={isAutoWidth}
      >
        {items.map((item, index) => (
          <MenuItem key={index} value={item.value}>
            {item.key}
          </MenuItem>
        ))}
      </Select>
    </FormControl>
  );
};

export default SelectSingleInput;
