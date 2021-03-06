﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GAB_ManagedIdentity.StorageProvider;
using Microsoft.AspNetCore.Mvc;

namespace GAB_ManagedIdentity.Controllers
{
    public class StorageAccountController : Controller
    {
        private readonly IBlobStorageProvider blobStorageProvider;
        public StorageAccountController(IBlobStorageProvider blobStorageProvider)
        {
            this.blobStorageProvider = blobStorageProvider;
        }
        public async Task<IActionResult> Index()
        {
            return View(await blobStorageProvider.GetContainersListAsync());
        }

        public async Task<IActionResult> Blobs(string containerName)
        {
            ViewData["containerName"] = containerName;
            return View(await blobStorageProvider.GetBlobsInContainerAsync(containerName));
        }

        public async Task<IActionResult> Download(string containerName, string blobName)
        {
            ViewData["containerName"] = containerName;
            var blobContentAsync = await blobStorageProvider.GetBlobContentAsync(containerName, blobName);
            var blobDownloadInfo = blobContentAsync.Value;
            var fileInfo = new FileInfo(blobName);
            return File(blobDownloadInfo.Content, blobDownloadInfo.ContentType, fileInfo.Name);
        }
    }
}