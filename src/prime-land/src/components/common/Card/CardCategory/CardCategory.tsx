// Copyright (c) 2024 - Jun Dev. All rights reserved

import { Card, CardProps } from '@mui/material';

import { ICategory } from '../../../../models';
import { GetProductImage } from '../../../../utils';
import { CardBody, CardThumbnail } from '../Common';

interface CardCategoryProps extends CardProps {
  children: React.ReactNode;
  data: ICategory;
}

const CardCategoryComponent = ({
  children,
  data,
  ...props
}: CardCategoryProps) => {
  return (
    <Card {...props}>
      <CardThumbnail
        src={GetProductImage(data.avatar)[0]}
        sx={{
          transition: '.25s ease-out',
          '&:hover': {
            transform: 'scale(1.05)',
            transition: '.25s ease-in',
            filler: 'brightness(.85)',
          },
        }}
      />
      <CardBody padding="1.25rem">{children}</CardBody>
    </Card>
  );
};

export default CardCategoryComponent;
