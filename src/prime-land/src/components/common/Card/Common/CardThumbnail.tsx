// Copyright (c) 2024 - Jun Dev. All rights reserved

import {
  Box,
  CardActions,
  CardMedia,
  CardMediaProps,
  Chip,
} from '@mui/material';
import { useNavigate } from 'react-router-dom';

import { createClassName } from '../../../../utils';

interface CardProductThumbnailProps extends CardMediaProps {
  isRedirect?: boolean;
  chipSize?: 'small' | 'medium';
  chipText?: Record<string, string>;
  classNameWrapper?: string;
}

const CardThumbnailComponent = (props: CardProductThumbnailProps) => {
  const {
    isRedirect = true,
    chipText,
    chipSize = 'small',
    classNameWrapper = '',
    className = '',
    src,
    onClick,
    ...cardMediaProps
  } = props;
  const hasBadgeText = chipText !== undefined;
  const navigate = useNavigate();

  return (
    <Box
      component="div"
      className={createClassName('card__thumbnail', classNameWrapper)}
    >
      <CardActions onClick={onClick} sx={{ padding: 0, overflow: 'hidden' }}>
        <CardMedia
          component="img"
          className={createClassName('card__thumbnail__picture', className)}
          image={src}
          {...cardMediaProps}
        />
      </CardActions>
      {hasBadgeText &&
        Object.entries(chipText).map(([key, value], index) =>
          isRedirect ? (
            <CardActions key={index} onClick={() => navigate(value)}>
              <Chip label={key} size={chipSize} />
            </CardActions>
          ) : (
            <Chip key={index} label={key} size={chipSize} />
          ),
        )}
    </Box>
  );
};

export default CardThumbnailComponent;
