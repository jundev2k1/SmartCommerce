// Copyright (c) 2024 - Jun Dev. All rights reserved

import {
  Avatar,
  Chip,
  ClickAwayListener,
  Grow,
  MenuItem,
  MenuList,
  Paper,
  Popper,
} from '@mui/material';
import { useEffect, useRef, useState } from 'react';
import { useTranslation } from 'react-i18next';
import { useDispatch } from 'react-redux';

import { languageCodeList, LanguageItem } from './LanguageSwitch.logic';
import { setLanguage } from '../../../redux/slices/languageSlice';

const LanguageSwitchComponent = () => {
  const [chooseItem, setChooseItem] = useState<LanguageItem>(
    languageCodeList[0],
  );
  const dispatch = useDispatch();
  const [open, setOpen] = useState(false);
  const anchorRef = useRef<HTMLDivElement>(null);
  const { t: translate } = useTranslation();

  const onToggle = () => {
    setOpen((prevOpen) => !prevOpen);
  };

  const onClose = () => {
    setOpen(false);
  };

  const onChoose = (index: number) => {
    const targetItem = languageCodeList[index];
    setChooseItem(targetItem);
    dispatch(setLanguage(targetItem.code));
  };

  function handleListKeyDown(event: React.KeyboardEvent) {
    if (event.key === 'Tab') {
      event.preventDefault();
      setOpen(false);
    } else if (event.key === 'Escape') {
      setOpen(false);
    }
  }

  const prevOpen = useRef(open);
  useEffect(() => {
    if (prevOpen.current === true && open === false) {
      anchorRef.current!.focus();
    }

    prevOpen.current = open;
  }, [open]);

  return (
    <>
      <div
        role="button"
        ref={anchorRef}
        id="language-button"
        aria-controls={open ? 'language-button' : undefined}
        aria-expanded={open ? 'true' : undefined}
        aria-haspopup="true"
        onClick={onToggle}
      >
        <Chip
          avatar={<Avatar alt="Language flag" src={chooseItem.srcImage} />}
          label={translate(chooseItem.title)}
        />
      </div>

      <Popper
        open={open}
        anchorEl={anchorRef.current}
        role={undefined}
        placement="bottom-start"
        transition
        disablePortal
      >
        {({ TransitionProps, placement }) => (
          <Grow
            {...TransitionProps}
            style={{
              transformOrigin:
                placement === 'bottom-start' ? 'left top' : 'left bottom',
            }}
          >
            <Paper>
              <ClickAwayListener onClickAway={onClose}>
                <MenuList
                  autoFocusItem={open}
                  id="composition-menu"
                  aria-labelledby="composition-button"
                  onKeyDown={handleListKeyDown}
                  onMouseLeave={onClose}
                >
                  {languageCodeList.map((item, index) => (
                    <MenuItem key={index} onClick={() => onChoose(index)}>
                      {translate(item.title)}
                    </MenuItem>
                  ))}
                </MenuList>
              </ClickAwayListener>
            </Paper>
          </Grow>
        )}
      </Popper>
    </>
  );
};

export default LanguageSwitchComponent;
