export interface Localization {
  badge: string;
  open: string;
  close: string;
  confirmEdit: {
    ok: string;
    cancel: string;
  };
  dataIterator: {
    noResultsText: string;
    loadingText: string;
  };
  dataTable: {
    itemsPerPageText: string;
    ariaLabel: {
      sortDescending: string;
      sortAscending: string;
      sortNone: string;
      activateNone: string;
      activateDescending: string;
      activateAscending: string;
    };
    sortBy: string;
  };
  dataFooter: {
    itemsPerPageText: string;
    itemsPerPageAll: string;
    nextPage: string;
    prevPage: string;
    firstPage: string;
    lastPage: string;
    pageText: string;
  };
  dateRangeInput: {
    divider: string;
  };
  datePicker: {
    itemsSelected: string;
    range: {
      title: string;
      header: string;
    };
    title: string;
    header: string;
    input: {
      placeholder: string;
    };
  };
  noDataText: string;
  carousel: {
    prev: string;
    next: string;
    ariaLabel: {
      delimiter: string;
    };
  };
  calendar: {
    moreEvents: string;
    today: string;
  };
  input: {
    clear: string;
    prependAction: string;
    appendAction: string;
    otp: string;
  };
  fileInput: {
    counter: string;
    counterSize: string;
  };
  timePicker: {
    am: string;
    pm: string;
  };
  pagination: {
    ariaLabel: {
      root: string;
      next: string;
      previous: string;
      page: string;
      currentPage: string;
      first: string;
      last: string;
    };
  };
  stepper: {
    next: string;
    prev: string;
  };
  rating: {
    ariaLabel: {
      item: string;
    };
  };
  loading: string;
  infiniteScroll: {
    loadMore: string;
    empty: string;
  };
}

const localization = {
  badge: 'Placa',
  open: 'Open',
  close: 'Cerrar',
  confirmEdit: {
    ok: 'OK',
    cancel: 'Cancelar'
  },
  dataIterator: {
    noResultsText: 'Ningún elemento coincide con la búsqueda',
    loadingText: 'Cargando...'
  },
  dataTable: {
    itemsPerPageText: 'Filas por página:',
    ariaLabel: {
      sortDescending: 'Orden descendente.',
      sortAscending: 'Orden ascendente.',
      sortNone: 'Sin ordenar.',
      activateNone: 'Pulse para quitar orden.',
      activateDescending: 'Pulse para ordenar de forma descendente.',
      activateAscending: 'Pulse para ordenar de forma ascendente.'
    },
    sortBy: 'Ordenado por'
  },
  dataFooter: {
    itemsPerPageText: 'Elementos por página:',
    itemsPerPageAll: 'Todos',
    nextPage: 'Página siguiente',
    prevPage: 'Página anterior',
    firstPage: 'Primera página',
    lastPage: 'Última página',
    pageText: '{0}-{1} de {2}'
  },
  dateRangeInput: {
    divider: 'a'
  },
  datePicker: {
    itemsSelected: '{0} Seleccionadas',
    range: {
      title: 'Seleccionar fechas',
      header: 'Introduce fechas'
    },
    title: 'Seleccione fecha',
    header: 'Introduce la fecha',
    input: {
      placeholder: 'Introduce la fecha'
    }
  },
  noDataText: 'No hay datos disponibles',
  carousel: {
    prev: 'Visual anterior',
    next: 'Visual siguiente',
    ariaLabel: {
      delimiter: 'Visual {0} de {1}'
    }
  },
  calendar: {
    moreEvents: '{0} más',
    today: 'Hoy'
  },
  input: {
    clear: 'Clear {0}',
    prependAction: '{0} prepended action',
    appendAction: '{0} appended action',
    otp: 'Por favor ingrese el carácter OTP {0}'
  },
  fileInput: {
    counter: '{0} archivos',
    counterSize: '{0} archivos ({1} en total)'
  },
  timePicker: {
    am: 'AM',
    pm: 'PM'
  },
  pagination: {
    ariaLabel: {
      root: 'Navegación de paginación',
      next: 'Página siguiente',
      previous: 'Página anterior',
      page: 'Ir a la página {0}',
      currentPage: 'Página actual, página {0}',
      first: 'Primera página',
      last: 'Última página'
    }
  },
  stepper: {
    next: 'Próxima',
    prev: 'Previa'
  },
  rating: {
    ariaLabel: {
      item: 'Puntuación {0} de {1}'
    }
  },
  loading: 'Cargando...',
  infiniteScroll: {
    loadMore: 'Carga',
    empty: 'No más'
  }
};

export default localization;