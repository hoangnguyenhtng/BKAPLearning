package com.library.library.service;

import com.library.library.dto.AdminDto;
import com.library.library.model.Admin;

public interface AdminService {
    Admin findByUsername(String username);

    Admin save(AdminDto adminDto);
}
