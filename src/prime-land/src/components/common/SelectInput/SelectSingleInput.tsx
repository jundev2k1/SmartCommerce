// Copyright (c) 2024 - Jun Dev. All rights reserved

import FormControl from '@mui/material/FormControl';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import Select, { SelectChangeEvent } from '@mui/material/Select';
import React, { useState } from 'react';

interface SelectSingleProps
  extends React.SelectHTMLAttributes<HTMLSelectElement> {
  label: string;
  items: [string, string | number][];
  defaultSelect: string | undefined;
  isAutoWidth: boolean;
}

const SelectSingleInput = (props: SelectSingleProps) => {
  const { id, label, items, defaultSelect, isAutoWidth = false } = props;
  const [selectValue, setSelectValue] = useState(defaultSelect);

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
        {items.map(([text, value], index) => (
          <MenuItem key={index} value={value}>
            {text}
          </MenuItem>
        ))}
      </Select>
    </FormControl>
  );
};

export default SelectSingleInput;
